using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.ProjectSite;

public class ProjectSiteService : ServiceBase<Domain.Entity.Budgeting.ProjectSite, ProjectSiteVm>, IProjectSiteService
{
    private readonly IProjectSitePersistence _projectSitePersistence;

    public ProjectSiteService(IDataPersistence<Domain.Entity.Budgeting.ProjectSite> persistence, IMapper mapper,
        IDistributedCache cache, IProjectSitePersistence projectSitePersistence) : base(persistence, mapper, cache)
    {
        _projectSitePersistence = projectSitePersistence;
    }

    public async Task<ProjectSiteVm[]> GetProjectSitesAsync(string tenant)
        => await GetCachedItemsAsync(() => _projectSitePersistence.GetProjectSitesAsync(tenant));

    public async Task<string[]> GetProjectSiteCodesAsync(string tenant)
    {
        var projectSiteCodes = await GetProjectSitesAsync(tenant);
        return projectSiteCodes.Select(x => x.copYear).ToArray();
    }
}