using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.SystemMenu.Queries;

public class SystemMenuQueryHandler : RequestHandlerBase, IRequestHandler<SystemMenuQuery, SystemMenuVm>
{
    private readonly ISystemMenuService _systemMenuService;

    public SystemMenuQueryHandler(ISystemMenuService systemMenuService)
    {
        _systemMenuService = systemMenuService;
    }

    public async Task<SystemMenuVm> Handle(SystemMenuQuery request, CancellationToken cancellationToken) =>
        await _systemMenuService.GetAsync(request.Tenant, request.Code);
}