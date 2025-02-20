using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.Runner;

public class RunnerService : ServiceBase<Domain.Entity.Budgeting.Runner, RunnerVm>, IRunnerService
{
    private readonly IRunnerPersistence _runnerPersistence;
    private readonly IMapper _mapper;

    public RunnerService(IDataPersistence<Domain.Entity.Budgeting.Runner> persistence, IMapper mapper,
        IDistributedCache cache, IRunnerPersistence runnerPersistence) : base(persistence, mapper, cache)
    {
        _runnerPersistence = runnerPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerVm[]> GetRunnersAsync(string tenant)
    {
        var entities = await _runnerPersistence.GetRunnersAsync(tenant);
        return _mapper.Map<RunnerVm[]>(entities);
    }

    public async Task<RunnerVm[]> GetAllRunnersByRegionAsync(string region)
    {
        var runners = await _runnerPersistence.GetAllRunnersByRegionAsync(region);
        return _mapper.Map<RunnerVm[]>(runners);
    }

    public async Task<RunnerVm[]> GetAllRunnersByBranchAsync(string tenant, string region)
    {
        var runners = await _runnerPersistence.GetAllRunnersByBranchAsync(tenant, region);
        return _mapper.Map<RunnerVm[]>(runners);
    }

    public async Task<bool> RunnerIsActiveAsync(string tenant, string runner, string branch)
    {
        var activeRunners = await GetAllRunnersByRegionAsync(branch);
        if (activeRunners == null || activeRunners.Length == 0)
            return false;

        var activeRunner = activeRunners.First();
        if (activeRunner == null) return false;

        if (activeRunner.Code != runner) return false;

        return activeRunner.Status == "60" || activeRunner.Status == "61";
    }

    public async Task<string[]> GetRunnerCodesAsync(string tenant)
    {
        var runners = await GetRunnersAsync(tenant);
        return runners.Select(x=>x.Code).ToArray();
    }
}