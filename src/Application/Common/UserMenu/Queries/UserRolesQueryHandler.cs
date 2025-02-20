using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.UserMenu.Queries;

public class UserRolesQueryHandler : RequestHandlerBase, IRequestHandler<UserRolesQuery, UserRoleVm[]>
{
    private readonly IUserMenuService _userMenuService;

    public UserRolesQueryHandler(IUserMenuService userMenuService)
    {
        this._userMenuService = userMenuService;
    }

    public async Task<UserRoleVm[]> Handle(UserRolesQuery request, CancellationToken cancellationToken) =>
        await _userMenuService.GetAllAsync(true);

}