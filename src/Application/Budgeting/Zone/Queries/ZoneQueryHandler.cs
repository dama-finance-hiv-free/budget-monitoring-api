using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Zone.Queries;

public class ZoneQueryHandler : RequestHandlerBase, IRequestHandler<ZoneQuery, ZoneVm>
{
    private readonly IZoneService _zoneService;

    public ZoneQueryHandler(IZoneService zoneService)
    {
        _zoneService = zoneService;
    }

    public async Task<ZoneVm> Handle(ZoneQuery request, CancellationToken cancellationToken) =>
        await _zoneService.GetAsync(request.Code, request.Code);
}