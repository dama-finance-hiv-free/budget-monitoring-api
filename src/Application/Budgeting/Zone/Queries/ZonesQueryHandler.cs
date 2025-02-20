using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Zone.Queries;

public class ZonesQueryHandler : RequestHandlerBase, IRequestHandler<ZonesQuery, ZoneVm[]>
{
    private readonly IZoneService _zoneService;

    public ZonesQueryHandler(IZoneService zoneService)
    {
        _zoneService = zoneService;
    }

    public async Task<ZoneVm[]> Handle(ZonesQuery request, CancellationToken cancellationToken) => 
        await _zoneService.GetAllAsync(true);
}
