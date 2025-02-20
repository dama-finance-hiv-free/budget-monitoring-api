using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.SystemMenu.Queries;

public class SystemMenusQueryHandler : RequestHandlerBase, IRequestHandler<SystemMenusQuery, SystemMenuVm[]>
{
    private readonly ISystemMenuService _systemMenuService;

    public SystemMenusQueryHandler(ISystemMenuService systemMenuService)
    {
        _systemMenuService = systemMenuService;
    }

    public async Task<SystemMenuVm[]> Handle(SystemMenusQuery request, CancellationToken cancellationToken) => 
        await _systemMenuService.GetAllAsync(true);
}