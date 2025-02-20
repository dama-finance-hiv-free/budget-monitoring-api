using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.Budget;

public class BudgetService : ServiceBase<Domain.Entity.Budgeting.Budget, BudgetVm>, IBudgetService
{
    private readonly IBudgetPersistence _budgetPersistence;
    private readonly IMapper _mapper;

    public BudgetService(IDataPersistence<Domain.Entity.Budgeting.Budget> persistence, IMapper mapper,
        IDistributedCache cache, IBudgetPersistence budgetPersistence) : base(persistence, mapper, cache)
    {
        _budgetPersistence = budgetPersistence;
        _mapper = mapper;
    }

    public async Task<BudgetVm[]> GetBudgetsAsync(string tenant)
    {
        var budgets = await _budgetPersistence.GetBudgetsAsync(tenant);
        return  _mapper.Map<BudgetVm[]>(budgets);
    }
}