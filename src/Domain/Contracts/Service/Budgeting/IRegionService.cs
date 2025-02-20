using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IRegionService : IServiceBase<RegionVm>
{
    Task<RegionVm[]> GetRegionsAsync();

    Task<string[]> GetRegionCodesAsync();
}