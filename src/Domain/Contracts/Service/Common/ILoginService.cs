using System;
using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Domain.Contracts.Service.Common;

public interface ILoginService: IDisposable
{
    Task<LoginVm> ProcessLoginAsync(UserConnectVm userInfo);
}