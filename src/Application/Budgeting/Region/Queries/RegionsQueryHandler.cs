using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Region.Queries;

public class RegionsQueryHandler : RequestHandlerBase, IRequestHandler<RegionsQuery, RegionVm[]>
{
    private readonly IRegionService _regionService;

    public RegionsQueryHandler(IRegionService regionService)
    {
        _regionService = regionService;
    }

    public async Task<RegionVm[]> Handle(RegionsQuery request, CancellationToken cancellationToken) => 
        await _regionService.GetAllAsync(true);
}
