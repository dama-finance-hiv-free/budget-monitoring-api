using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Privilege.Queries;

public class PrivilegesQueryHandler : RequestHandlerBase, IRequestHandler<PrivilegesQuery, PrivilegeVm[]>
{
    private readonly IPrivilegeService _privilegeService;

    public PrivilegesQueryHandler(IPrivilegeService privilegeService)
    {
        _privilegeService = privilegeService;
    }

    public async Task<PrivilegeVm[]> Handle(PrivilegesQuery request, CancellationToken cancellationToken) => 
        await _privilegeService.GetAllAsync(true);
}