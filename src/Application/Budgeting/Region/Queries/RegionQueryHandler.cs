using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Region.Queries;

public class RegionQueryHandler : RequestHandlerBase, IRequestHandler<RegionQuery, RegionVm>
{
    private readonly IRegionService _regionService;

    public RegionQueryHandler(IRegionService regionService)
    {
        _regionService = regionService;
    }

    public async Task<RegionVm> Handle(RegionQuery request, CancellationToken cancellationToken) =>
        await _regionService.GetAsync(request.Tenant, request.Code);
}