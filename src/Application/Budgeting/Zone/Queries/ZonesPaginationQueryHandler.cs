using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Zone.Queries;

public class ZonesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<ZonesPaginationQuery, ZoneVm[]>
{
    private readonly IZoneService _zoneService;

    public ZonesPaginationQueryHandler(IZoneService zoneService)
    {
        _zoneService = zoneService;
    }

    public async Task<ZoneVm[]> Handle(ZonesPaginationQuery request, CancellationToken cancellationToken) =>
        await _zoneService.GetAllAsync(true, request.Page, request.Count);
}
