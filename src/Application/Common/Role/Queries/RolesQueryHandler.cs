using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Role.Queries;

public class RolesQueryHandler : RequestHandlerBase, IRequestHandler<RolesQuery, RoleVm[]>
{
    private readonly IRoleService _roleService;

    public RolesQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<RoleVm[]> Handle(RolesQuery request, CancellationToken cancellationToken) => 
        await _roleService.GetAllAsync(true);
}