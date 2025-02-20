using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RegionRunnerPeriod.Queries;

public class RegionRunnerPeriodQueryHandler : RequestHandlerBase, IRequestHandler<RegionRunnerPeriodQuery, RegionRunnerPeriodVm>
{
    private readonly IRegionRunnerPeriodService _regionRunnerPeriodService;

    public RegionRunnerPeriodQueryHandler(IRegionRunnerPeriodService regionRunnerPeriodService)
    {
        _regionRunnerPeriodService = regionRunnerPeriodService;
    }

    public async Task<RegionRunnerPeriodVm> Handle(RegionRunnerPeriodQuery request, CancellationToken cancellationToken) =>
        await _regionRunnerPeriodService.GetAsync(request.Tenant, request.Region);
}