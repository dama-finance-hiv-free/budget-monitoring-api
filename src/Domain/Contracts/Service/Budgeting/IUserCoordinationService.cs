using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IUserCoordinationService : IServiceBase<UserCoordinationVm>
{
    Task<UserCoordinationVm[]> GetUserUserCoordinationAsync(string tenant, string user);
    Task<string[]> GetUserUserCoordinationCodesAsync(string tenant, string user);
}