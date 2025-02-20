using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Zone.Queries;

public class ZoneCountQueryHandler : RequestHandlerBase, IRequestHandler<ZoneCountQuery, int>
{
    private readonly IZoneService _zoneService;

    public ZoneCountQueryHandler(IZoneService zoneService)
    {
        _zoneService = zoneService;
    }

    public async Task<int> Handle(ZoneCountQuery request, CancellationToken cancellationToken) =>
        await _zoneService.GetCount(true);
}