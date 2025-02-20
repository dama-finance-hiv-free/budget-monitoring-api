using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.RunnerComponentHistory;

public class RunnerComponentHistoryService :
    ServiceBase<Domain.Entity.Budgeting.RunnerComponentHistory, RunnerComponentHistoryVm>,
    IRunnerComponentHistoryService
{
    private readonly IRunnerComponentHistoryPersistence _runnerComponentHistoryPersistence;
    private readonly IMapper _mapper;

    public RunnerComponentHistoryService(IDataPersistence<Domain.Entity.Budgeting.RunnerComponentHistory> persistence,
        IMapper mapper, IDistributedCache cache, IRunnerComponentHistoryPersistence runnerComponentHistoryPersistence) :
        base(persistence, mapper, cache)
    {
        _runnerComponentHistoryPersistence = runnerComponentHistoryPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerComponentHistoryVm[]> GetRunnerComponentHistoriesAsync(string tenant)
    {
        var runnerComponentHistories =
            await _runnerComponentHistoryPersistence.GetRunnerComponentHistoriesAsync(tenant);
        return  _mapper.Map<RunnerComponentHistoryVm[]>(runnerComponentHistories);
    }
}