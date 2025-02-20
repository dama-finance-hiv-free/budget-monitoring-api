using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.UserCoordination;

public class UserCoordinationService : ServiceBase<Domain.Entity.Budgeting.UserCoordination, UserCoordinationVm>,
    IUserCoordinationService
{
    private readonly IUserCoordinationPersistence _userCoordinationPersistence;
    private readonly IMapper _mapper;

    public UserCoordinationService(IDataPersistence<Domain.Entity.Budgeting.UserCoordination> persistence,
        IMapper mapper, IDistributedCache cache, IUserCoordinationPersistence userCoordinationPersistence) : base(
        persistence, mapper, cache)
    {
        _userCoordinationPersistence = userCoordinationPersistence;
        _mapper = mapper;
    }

    public async Task<UserCoordinationVm[]> GetUserUserCoordinationAsync(string tenant, string user)
    {
        var userCoordination = await _userCoordinationPersistence.GetUserCoordinationAsync(tenant, user);
        return  _mapper.Map<UserCoordinationVm[]>(userCoordination);
    }

    public async Task<string[]> GetUserUserCoordinationCodesAsync(string tenant, string user)
    {
        var userCoordination = await GetUserUserCoordinationAsync(tenant, user);
        return userCoordination.Select(x => x.Coordination).ToArray().Concat(new List<string> { user }).ToArray();
    }
}