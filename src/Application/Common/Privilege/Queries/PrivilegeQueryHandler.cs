using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Privilege.Queries;

public class PrivilegeQueryHandler : RequestHandlerBase, IRequestHandler<PrivilegeQuery, PrivilegeVm>
{
    private readonly IPrivilegeService _privilegeService;

    public PrivilegeQueryHandler(IPrivilegeService privilegeService)
    {
        _privilegeService = privilegeService;
    }

    public async Task<PrivilegeVm> Handle(PrivilegeQuery request, CancellationToken cancellationToken) =>
        await _privilegeService.GetAsync(request.Tenant, request.Code);
}