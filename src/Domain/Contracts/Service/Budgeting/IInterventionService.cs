using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IInterventionService : IServiceBase<InterventionVm>
{
    Task<InterventionVm[]> GetInterventionsAsync(string tenant);

    Task<string[]> GetInterventionCodesAsync(string tenant);
}