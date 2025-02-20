using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.UserMenu.Queries;

public class UserRoleQueryHandler : RequestHandlerBase, IRequestHandler<UserRoleQuery, UserRoleVm>
{
    private readonly IUserMenuService _userMenuService;

    public UserRoleQueryHandler(IUserMenuService userMenuService)
    {
        this._userMenuService = userMenuService;
    }

    public async Task<UserRoleVm> Handle(UserRoleQuery request, CancellationToken cancellationToken) =>
        await _userMenuService.GetAsync(request.Code, request.Code);
}