using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.RunnerPeriod;

public class RunnerPeriodService : ServiceBase<Domain.Entity.Budgeting.RunnerPeriod, RunnerPeriodVm>, IRunnerPeriodService
{
    private readonly IRunnerPeriodPersistence _runnerPeriodPersistence;
    private readonly IMapper _mapper;

    public RunnerPeriodService(IDataPersistence<Domain.Entity.Budgeting.RunnerPeriod> persistence, IMapper mapper,
        IDistributedCache cache, IRunnerPeriodPersistence runnerPeriodPersistence) : base(persistence, mapper, cache)
    {
        _runnerPeriodPersistence = runnerPeriodPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerPeriodVm[]> GetRunnerPeriodsAsync(string tenant)
    {
        var runnerPeriods = await _runnerPeriodPersistence.GetRunnerPeriodsAsync(tenant);
        return  _mapper.Map<RunnerPeriodVm[]>(runnerPeriods);
    }

    public async Task<string[]>
        GetRunnerPeriodHistoryCodesAsync(string tenant, string region, string copYear, string project) =>
        await _runnerPeriodPersistence.GetRunnerPeriodHistoryCodesAsync(tenant, region, copYear, project);

    public async Task<string[]> GetRunnerPeriodCodesAsync(string tenant)
    {
        var runnerPeriods = await GetRunnerPeriodsAsync(tenant);
        return runnerPeriods.Select(x => x.Code).ToArray();
    }
}