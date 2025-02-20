using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.BranchStation.Queries;

public class BranchStationsQueryHandler : RequestHandlerBase, IRequestHandler<BranchStationsQuery, BranchStationVm[]>
{
    private readonly IBranchStationService _branchStationsService;

    public BranchStationsQueryHandler(IBranchStationService branchStationsService)
    {
        _branchStationsService = branchStationsService;
    }

    public async Task<BranchStationVm[]> Handle(BranchStationsQuery request, CancellationToken cancellationToken) => 
        await _branchStationsService.GetAllAsync(true);
}