using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.Project;

public class ProjectService : ServiceBase<Domain.Entity.Budgeting.Project, ProjectVm>, IProjectService
{
    private readonly IProjectPersistence _projectPersistence;

    public ProjectService(IDataPersistence<Domain.Entity.Budgeting.Project> persistence, IMapper mapper,
        IDistributedCache cache, IProjectPersistence projectPersistence) : base(persistence, mapper, cache)
    {
        _projectPersistence = projectPersistence;
    }

    public async Task<ProjectVm[]> GetProjectsAsync(string tenant)
        => await GetCachedItemsAsync(() => _projectPersistence.GetProjectsAsync(tenant));

    public async Task<string[]> GetProjectCodesAsync(string tenant)
    {
        var projectCodes = await GetProjectsAsync(tenant);
        return projectCodes.Select(x => x.Code).ToArray();
    }
}