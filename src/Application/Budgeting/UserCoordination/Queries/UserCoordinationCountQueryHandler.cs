using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.UserCoordination.Queries;

public class UserCoordinationCountQueryHandler : RequestHandlerBase, IRequestHandler<UserCoordinationCountQuery, int>
{
    private readonly IUserCoordinationService _userCoordinationService;

    public UserCoordinationCountQueryHandler(IUserCoordinationService userCoordinationService)
    {
        _userCoordinationService = userCoordinationService;
    }

    public async Task<int> Handle(UserCoordinationCountQuery request, CancellationToken cancellationToken) =>
        await _userCoordinationService.GetCount(true);
}