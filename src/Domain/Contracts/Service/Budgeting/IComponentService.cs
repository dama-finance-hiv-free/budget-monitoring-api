using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IComponentService : IServiceBase<ComponentVm>
{
    Task<ComponentVm[]> GetComponentsAsync(string tenant);
    Task<string[]> GetComponentCodesAsync(string tenant);
}