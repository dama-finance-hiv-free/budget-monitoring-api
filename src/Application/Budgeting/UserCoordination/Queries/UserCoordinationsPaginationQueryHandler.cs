using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.UserCoordination.Queries;

public class UserCoordinationsPaginationQueryHandler : RequestHandlerBase, IRequestHandler<UserCoordinationsPaginationQuery, UserCoordinationVm[]>
{
    private readonly IUserCoordinationService _userCoordinationService;

    public UserCoordinationsPaginationQueryHandler(IUserCoordinationService userCoordinationService)
    {
        _userCoordinationService = userCoordinationService;
    }

    public async Task<UserCoordinationVm[]> Handle(UserCoordinationsPaginationQuery request, CancellationToken cancellationToken) =>
        await _userCoordinationService.GetAllAsync(true, request.Page, request.Count);
}
