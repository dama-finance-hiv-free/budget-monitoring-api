using System.Threading.Tasks;
using AutoMapper;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Common.UserBranch;

public class UserBranchService : ServiceBase<Domain.Entity.Common.UserBranch, UserBranchVm>, IUserBranchService
{
    private readonly IUserBranchPersistence _userBranchPersistence;

    public UserBranchService(IUserBranchPersistence persistence, IMapper mapper,
        IDistributedCache cache) : base(persistence, mapper, cache)
    {
        _userBranchPersistence = persistence;
    }

    public async Task<string> GetUserDefaultBranchAsync(string tenant, string user) =>
        await _userBranchPersistence.GetUserDefaultBranchAsync(tenant, user);
}