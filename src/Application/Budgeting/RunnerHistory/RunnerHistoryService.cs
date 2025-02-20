using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.RunnerHistory;

public class RunnerHistoryService : ServiceBase<Domain.Entity.Budgeting.RunnerHistory, RunnerHistoryVm>, IRunnerHistoryService
{
    private readonly IRunnerHistoryPersistence _runnerHistoryPersistence;
    private readonly IMapper _mapper;

    public RunnerHistoryService(IDataPersistence<Domain.Entity.Budgeting.RunnerHistory> persistence, IMapper mapper,
        IDistributedCache cache, IRunnerHistoryPersistence runnerHistoryPersistence) : base(persistence, mapper, cache)
    {
        _runnerHistoryPersistence = runnerHistoryPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerHistoryVm[]> GetRunnerHistoriesAsync(string tenant)
    {
        var runnerHistories = await _runnerHistoryPersistence.GetRunnerHistoriesAsync(tenant);
        return  _mapper.Map<RunnerHistoryVm[]>(runnerHistories);
    }
}