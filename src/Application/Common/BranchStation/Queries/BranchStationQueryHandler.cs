using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.BranchStation.Queries;

public class BranchStationQueryHandler : RequestHandlerBase, IRequestHandler<BranchStationQuery, BranchStationVm>
{
    private readonly IBranchStationService _branchStationService;

    public BranchStationQueryHandler(IBranchStationService branchStationService)
    {
        _branchStationService = branchStationService;
    }

    public async Task<BranchStationVm> Handle(BranchStationQuery request, CancellationToken cancellationToken) =>
        await _branchStationService.GetAsync(request.Tenant, request.Code);
}