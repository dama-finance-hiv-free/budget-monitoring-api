using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface ICopYearBudgetCodeService : IServiceBase<CopYearBudgetCodeVm>
{
    Task<CopYearBudgetCodeVm[]> GetCopYearBudgetCodesAsync(string tenant);
}