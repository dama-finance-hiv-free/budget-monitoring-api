using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.BudgetExecution ;

public class BudgetExecutionService
    : ServiceBase<Domain.Entity.Budgeting.Activity, BudgetExecutionVm>,
    IBudgetExecutionService
{

    private readonly IActivityHistoryPersistence _activityHistoryPersistence;

    public BudgetExecutionService(IDataPersistence<Domain.Entity.Budgeting.Activity> persistence,
        IMapper mapper, IDistributedCache cache, IActivityHistoryPersistence activityHistoryPersistence)
        : base(persistence, mapper, cache)
    {
        _activityHistoryPersistence = activityHistoryPersistence;
    }

    public Task<BudgetExecutionVm[]> GetBudgetExecutionsAsync(BudgetAnalysisOptions options)
        => _activityHistoryPersistence.GetBudgetExecutionsAsync(options);
}