using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class DailyDataPersistence : RepositoryBase<PrintDailyData>, IDailyDataPersistence
{
    private readonly IActivityPersistence _activityPersistence;
    private readonly ISitePersistence _sitePersistence;
    private readonly IDistrictPersistence _districtPersistence;
    private readonly IRegionPersistence _regionPersistence;
    private readonly IBranchPersistence _branchPersistence;
    private readonly IMapper _mapper;
    public DailyDataPersistence(IDatabaseFactory databaseFactory, 
        IActivityPersistence activityPersistence, 
        IDistrictPersistence districtPersistence, 
        ISitePersistence sitePersistence, 
        IRegionPersistence regionPersistence,
        IMapper mapper, IBranchPersistence branchPersistence)
        : base(databaseFactory)
    {
        _activityPersistence = activityPersistence;
        _districtPersistence = districtPersistence;
        _sitePersistence = sitePersistence;
        _regionPersistence = regionPersistence;
        _branchPersistence = branchPersistence;
        _mapper = mapper;
    }


    public async Task<PrintDailyData[]> GetDailyDataAsync(string tenant) => await GetAllAsync();

    protected override async Task<PrintDailyData> ItemToGetAsync(string tenant, string zone) =>
        await GetFirstOrDefaultAsync(x => x.UserCode == zone);

    protected override async Task<PrintDailyData> ItemToGetAsync(PrintDailyData zone) =>
        await GetFirstOrDefaultAsync(x => x.UserCode == zone.UserCode);

    public async Task<DailyDataVm[]> GetDailyDataAsync(DailyDataOptions options)
    {
        try
        {
            var districtRepository = await _districtPersistence.GetAllAsync();
            var districts = districtRepository.Where(x => x.CopYear == "04" && x.Project == "01").ToArray();
            var districtCodes = districts.Select(x => x.Code).ToArray();

            var branchRepository = await _branchPersistence.GetAllAsync();
            var branches = branchRepository.Where(x => x.Code == options.Branch).ToArray();
            var branchCodes = branches.Select(x => x.Region);

            var regionRepository = await _regionPersistence.GetAllAsync();
            var regions = regionRepository.Where(x => branchCodes.Contains(x.Code)).ToArray();
            var regionCodes = regions.Select(x => x.Code);

            var siteRepository = await _sitePersistence.GetAllAsync();
            //var sites = siteRepository.Where(x => x.SiteType == "01" && districtCodes.Contains(x.District) && regionCodes.Contains(x.Region)).ToArray();
            var sites = siteRepository.Where(x => x.SiteType == "01" && districtCodes.Contains(x.District)).ToArray();
            var siteCodes = sites.Select(x => x.Code).ToArray();

            var activity = await _activityPersistence.GetAsync(x => siteCodes.Contains(x.Site));
            var activities = await _activityPersistence.GetAllAsync();

            var site = await _sitePersistence.GetAsync(x => x.Code == activity.Site);


            var dataLine = await DbSet.Where(x => x.UserCode == activity.UserCode).FirstOrDefaultAsync();
            var previousReceipts = activities.Where(t => t.Site == site.Code && t.UserCode == options.CurrentUser && t.ServerDate.Date < dataLine.TransDate.Date).ToArray();
            var sumOfPreviousReceipts = previousReceipts.Select(t => t.Amount).ToArray().Sum();

            var todayReceipts = activities.Where(t => t.Site == site.Code && t.UserCode == options.CurrentUser && t.ServerDate.Date == dataLine.TransDate.Date).ToArray();
            var sumOfTodayReceipt = todayReceipts.Select(x => x.Amount).ToArray().Sum();
            var totalReceipt = sumOfPreviousReceipts + sumOfTodayReceipt;

            if (dataLine != null)
            {
                var result = DbSet.Remove(dataLine);
                result.Context.SaveChanges();
            }

            var obj = new PrintDailyData
            {
                UserCode = activity.UserCode,
                User = activity.UserCode,
                UserName = activity.UserCode,
                Site = activity.Site,
                SiteName = site.Description,
                TransDate = activity.TransDate,
                PreviousReceipts = sumOfPreviousReceipts,
                TodayReceipts = sumOfTodayReceipt,
                TotalReceipts = totalReceipt
            };

            var save = await AddAsync(obj);
            if (save.Status != RepositoryActionStatus.Created)
            {
                throw new Exception();
            }

            var data = _mapper.Map<PrintDailyData[], DailyDataVm[]>(DbSet.OrderByDescending(x => x.TransDate).ToArray());

            return data;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}