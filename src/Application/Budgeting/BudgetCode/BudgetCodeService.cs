using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.BudgetCode;

public class BudgetCodeService : ServiceBase<Domain.Entity.Budgeting.BudgetCode, BudgetCodeVm>, IBudgetCodeService
{
    private readonly IBudgetCodePersistence _budgetCodePersistence;

    public BudgetCodeService(IDataPersistence<Domain.Entity.Budgeting.BudgetCode> persistence, IMapper mapper,
        IDistributedCache cache, IBudgetCodePersistence budgetCodePersistence) : base(persistence, mapper, cache)
    {
        _budgetCodePersistence = budgetCodePersistence;
    }

    public async Task<BudgetCodeVm[]> GetBudgetCodesAsync(string tenant)
        => await GetCachedItemsAsync(() => _budgetCodePersistence.GetBudgetCodesAsync(tenant));
  

    public async Task<string[]> GetBudgetCodeCodesAsync(string tenant)
    {
        var budgetCodes = await GetBudgetCodesAsync(tenant);
        return budgetCodes.Select(x => x.Code).ToArray();
    }
}