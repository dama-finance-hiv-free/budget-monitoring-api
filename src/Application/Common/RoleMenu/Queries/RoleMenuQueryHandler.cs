using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.RoleMenu.Queries;

public class RoleMenuQueryHandler : RequestHandlerBase, IRequestHandler<RoleMenuQuery, SystemMenuVm[]>
{
    private readonly ISystemMenuService _systemMenuService;

    public RoleMenuQueryHandler(ISystemMenuService systemMenuService)
    {
        _systemMenuService = systemMenuService;
    }

    public async Task<SystemMenuVm[]> Handle(RoleMenuQuery request, CancellationToken cancellationToken) =>
        await _systemMenuService.GetRoleMenusAsync(request.Tenant, request.Role);
}