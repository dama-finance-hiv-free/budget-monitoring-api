using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RegionRunnerPeriod.Queries;

public class RegionRunnerPeriodsPaginationQueryHandler : RequestHandlerBase, IRequestHandler<RegionRunnerPeriodsPaginationQuery, RegionRunnerPeriodVm[]>
{
    private readonly IRegionRunnerPeriodService _regionRunnerperiodService;

    public RegionRunnerPeriodsPaginationQueryHandler(IRegionRunnerPeriodService regionRunnerperiodService)
    {
        _regionRunnerperiodService = regionRunnerperiodService;
    }

    public async Task<RegionRunnerPeriodVm[]> Handle(RegionRunnerPeriodsPaginationQuery request, CancellationToken cancellationToken) =>
        await _regionRunnerperiodService.GetAllAsync(true, request.Page, request.Count);
}
