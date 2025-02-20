using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Domain.Contracts.Service.Common;

public interface IUserService : IServiceBase<UserVm>
{
    Task ConnectUserAsync(UserConnectVm userInfo);
    Task DisconnectUserAsync(UserConnectVm userInfo);
}