using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Region.Queries;

public class RegionCountQueryHandler : RequestHandlerBase, IRequestHandler<RegionCountQuery, int>
{
    private readonly IRegionService _regionService;

    public RegionCountQueryHandler(IRegionService regionService)
    {
        _regionService = regionService;
    }

    public async Task<int> Handle(RegionCountQuery request, CancellationToken cancellationToken) =>
        await _regionService.GetCount(true);
}