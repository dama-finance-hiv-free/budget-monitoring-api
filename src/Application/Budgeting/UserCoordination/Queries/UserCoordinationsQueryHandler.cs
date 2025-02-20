using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.UserCoordination.Queries;

public class UserCoordinationsQueryHandler : RequestHandlerBase, IRequestHandler<UserCoordinationsQuery, UserCoordinationVm[]>
{
    private readonly IUserCoordinationService _userCoordinationTypeService;

    public UserCoordinationsQueryHandler(IUserCoordinationService userCoordinationTypeService)
    {
        _userCoordinationTypeService = userCoordinationTypeService;
    }

    public async Task<UserCoordinationVm[]> Handle(UserCoordinationsQuery request, CancellationToken cancellationToken) => 
        await _userCoordinationTypeService.GetAllAsync(true);
}
