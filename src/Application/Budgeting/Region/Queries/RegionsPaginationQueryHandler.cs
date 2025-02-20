using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Region.Queries;

public class RegionsPaginationQueryHandler : RequestHandlerBase, IRequestHandler<RegionsPaginationQuery, RegionVm[]>
{
    private readonly IRegionService _regionService;

    public RegionsPaginationQueryHandler(IRegionService regionService)
    {
        _regionService = regionService;
    }

    public async Task<RegionVm[]> Handle(RegionsPaginationQuery request, CancellationToken cancellationToken) =>
        await _regionService.GetAllAsync(true, request.Page, request.Count);
}
