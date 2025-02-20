using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RegionRunnerPeriod.Queries;

public class RegionRunnerPeriodCountQueryHandler : RequestHandlerBase, IRequestHandler<RegionRunnerPeriodCountQuery, int>
{
    private readonly IRegionRunnerPeriodService _regionRunnerPeriodService;

    public RegionRunnerPeriodCountQueryHandler(IRegionRunnerPeriodService regionRunnerPeriodService)
    {
        _regionRunnerPeriodService = regionRunnerPeriodService;
    }

    public async Task<int> Handle(RegionRunnerPeriodCountQuery request, CancellationToken cancellationToken) =>
        await _regionRunnerPeriodService.GetCount(true);
}