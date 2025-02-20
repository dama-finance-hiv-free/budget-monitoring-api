using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Common.User;

public class UserService : ServiceBase<Domain.Entity.Common.User, UserVm>, IUserService
{
    private readonly IUserPersistence _userPersistence;

    public UserService(IDataPersistence<Domain.Entity.Common.User> persistence, IMapper mapper, IDistributedCache cache,
        IUserPersistence userPersistence) : base(persistence, mapper, cache)
    {
        _userPersistence = userPersistence;
    }

    public async Task ConnectUserAsync(UserConnectVm userInfo)
    {
        var user = new Domain.Entity.Common.User
        {
            Tenant = userInfo.Tenant,
            Code = userInfo.Code,
            Connected = "01",
            Computer = userInfo.NetBiosName,
            DeviceSerial = userInfo.DeviceSerial
        };
        await _userPersistence.ConnectUserAsync(user);
    }

    public async Task DisconnectUserAsync(UserConnectVm userInfo)
    {
        var user = new Domain.Entity.Common.User
        {
            Tenant = userInfo.Tenant,
            Code = userInfo.Code,
            Connected = "02",
            Computer = string.Empty,
            DeviceSerial = string.Empty
        };
        await _userPersistence.DisconnectUsersAsync(user);
    }
}