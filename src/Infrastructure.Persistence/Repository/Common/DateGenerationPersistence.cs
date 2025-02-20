using System;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class DateGenerationPersistence : RepositoryBase<DateGeneration>, IDateGenerationPersistence
{
    public DateGenerationPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<DateGeneration[]> GetDateGenerationsAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    public RepositoryActionResult<DateGeneration> SaveDatGenAsync(DateGeneration dateGeneration)
    {
        try
        {
            var existingDatGen = Context.DateGenerationSet.FirstOrDefault(dg => dg.Branch == dateGeneration.Branch);

            if (existingDatGen == null)
            {
                return new RepositoryActionResult<DateGeneration>(dateGeneration, RepositoryActionStatus.NotFound);
            }

            var saveDatGen = new DateGenerationHistory()
            {
                Branch = existingDatGen.Branch,
                TransDate = existingDatGen.TransDate,
                TransDay = existingDatGen.TransDay,
                TransMonth = existingDatGen.TransMonth,
                TransYear = existingDatGen.TransYear,
                PrevDay = existingDatGen.PrevDay,
                WeekStart = existingDatGen.WeekStart,
                WeekEnd = existingDatGen.WeekEnd,
                MonthStart = existingDatGen.MonthStart,
                MonthEnd = existingDatGen.MonthEnd,
                LastTransDate = existingDatGen.LastTransDate
            };

            Context.DateGenerationHistorySet.Add(saveDatGen);

            var result = Context.SaveChanges();
            return result > 0
                ? new RepositoryActionResult<DateGeneration>(dateGeneration, RepositoryActionStatus.Created)
                : new RepositoryActionResult<DateGeneration>(dateGeneration, RepositoryActionStatus.NothingModified, null);
        }
        catch (Exception ex)
        {
            return new RepositoryActionResult<DateGeneration>(null, RepositoryActionStatus.Error, ex);
        }

    }

    public RepositoryActionResult<DateGeneration> DeleteDateGenerationAsync(string branch)
    {
        try
        {
            var exp = Context.DateGenerationSet.FirstOrDefault(d => d.Branch == branch);
            if (exp == null)
                return new RepositoryActionResult<DateGeneration>(null, RepositoryActionStatus.NotFound);
            Context.DateGenerationSet.Remove(exp);
            Context.SaveChanges();
            return new RepositoryActionResult<DateGeneration>(null, RepositoryActionStatus.Deleted);
        }
        catch (Exception ex)
        {
            return new RepositoryActionResult<DateGeneration>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<DateTime> GetLastTransDateAsync(string branch, DateTime transDate)
    {
        var transDates = await Context.DateGenerationHistorySet.Where(x => x.Branch == branch)
            .Select(x => x.TransDate).ToArrayAsync();

        var currentDateArray = new[]
        {
            transDate
        };

        var dateTimes = transDates.Concat(currentDateArray);

        return dateTimes.OrderByDescending(x => x).FirstOrDefault();
    }

    public async Task<bool> DateAlreadyUsedAsync(string branch, DateTime transDate)
    {
        return await Context.DateGenerationHistorySet.FirstOrDefaultAsync(d =>
            d.Branch == branch &&
            d.TransDate.Date == transDate.Date) != null;
    }

    protected override async Task<DateGeneration> ItemToGetAsync(string tenant, string branch) =>
        await GetFirstOrDefaultAsync(x => x.Tenant == tenant && x.Branch == branch);
}