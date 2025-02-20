using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Role.Queries;

public class RoleQueryHandler : RequestHandlerBase, IRequestHandler<RoleQuery, RoleVm>
{
    private readonly IRoleService _roleService;

    public RoleQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<RoleVm> Handle(RoleQuery request, CancellationToken cancellationToken) =>
        await _roleService.GetAsync(request.Tenant, request.Code);
}