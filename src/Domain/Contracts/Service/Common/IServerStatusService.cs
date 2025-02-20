using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Domain.Contracts.Service.Common;

public interface IServerStatusService : IServiceBase<ServerStatusVm>
{
    Task<ServerStatusVm> GetServerStatusAsync(string tenant, string user);
    Task<ServerStatusVm[]> GetServerStatusesAsync(string tenant);
}