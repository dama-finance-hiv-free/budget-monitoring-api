using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface ICopYearService : IServiceBase<CopYearVm>
{
    Task<CopYearVm[]> GetCopYearsAsync(string tenant);

    Task<string[]> GetCopYearCodesAsync(string tenant);
    Task<CopYearVm> GetCopYearAsync(string tenant, string code);
}