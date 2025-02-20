using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RegionRunnerPeriod.Queries;

public class RegionRunnerPeriodsQueryHandler : RequestHandlerBase, IRequestHandler<RegionRunnerPeriodsQuery, RegionRunnerPeriodVm[]>
{
    private readonly IRegionRunnerPeriodService _regionRunnerperiodService;

    public RegionRunnerPeriodsQueryHandler(IRegionRunnerPeriodService regionRunnerperiodService)
    {
        _regionRunnerperiodService = regionRunnerperiodService;
    }

    public async Task<RegionRunnerPeriodVm[]> Handle(RegionRunnerPeriodsQuery request, CancellationToken cancellationToken) => 
        await _regionRunnerperiodService.GetAllAsync(true);
}
