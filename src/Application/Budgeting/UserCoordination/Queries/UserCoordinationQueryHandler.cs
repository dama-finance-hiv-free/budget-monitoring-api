using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.UserCoordination.Queries;

public class UserCoordinationQueryHandler : RequestHandlerBase, IRequestHandler<UserCoordinationQuery, UserCoordinationVm>
{
    private readonly IUserCoordinationService _userCoordinationtypeService;

    public UserCoordinationQueryHandler(IUserCoordinationService userCoordinationtypeService)
    {
        _userCoordinationtypeService = userCoordinationtypeService;
    }

    public async Task<UserCoordinationVm> Handle(UserCoordinationQuery request, CancellationToken cancellationToken) =>
        await _userCoordinationtypeService.GetAsync(request.User, request.User);
}