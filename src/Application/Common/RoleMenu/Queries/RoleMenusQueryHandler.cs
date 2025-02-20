using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.RoleMenu.Queries;

public class RoleMenusQueryHandler : RequestHandlerBase, IRequestHandler<RoleMenusQuery, RoleMenuVm[]>
{
    private readonly IRoleMenuService _roleMenuService;

    public RoleMenusQueryHandler(IRoleMenuService roleMenuService)
    {
        _roleMenuService = roleMenuService;
    }

    public async Task<RoleMenuVm[]> Handle(RoleMenusQuery request, CancellationToken cancellationToken) => 
        await _roleMenuService.GetAllAsync(true);
}