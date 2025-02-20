using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IDistrictService : IServiceBase<DistrictVm>
{
    Task<DistrictVm[]> GetDistrictsAsync(string tenant);
}