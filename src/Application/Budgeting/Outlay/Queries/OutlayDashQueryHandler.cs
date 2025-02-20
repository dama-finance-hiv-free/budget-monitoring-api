using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Queries;

public class OutlayDashQueryHandler : RequestHandlerBase, IRequestHandler<OutlayDashQuery, OutlayDashVm[]>
{
    private readonly IOutlayPersistence _outlayPersistence;
    private readonly IRunnerPersistence _runnerPersistence;

    public OutlayDashQueryHandler(IOutlayPersistence outlayPersistence, IRunnerPersistence runnerPersistence)
    {
        _outlayPersistence = outlayPersistence;
        _runnerPersistence = runnerPersistence;
    }

    public async Task<OutlayDashVm[]> Handle(OutlayDashQuery request, CancellationToken cancellationToken)
    {
        var runner = await _runnerPersistence.GetActiveRunnerAsync(request.Region, "01");

        if (runner == null)
            return null;

        var componentOneOutlays = 
            await _outlayPersistence.GetOutlayDashAsync(request.Tenant, request.Region,"01", runner.CopYear);
        const int periodDivider = 13;
        foreach (var outlay in componentOneOutlays)
        {
            outlay.PeriodTarget = outlay.AnnualTarget / periodDivider;
            outlay.PeriodBudget = outlay.ComponentBudget / periodDivider;
        }
        var componentTwoOutlays = 
            await _outlayPersistence.GetOutlayDashAsync(request.Tenant, request.Region, "02", runner.CopYear);

        foreach (var outlay in componentTwoOutlays)
        {
            outlay.PeriodTarget = outlay.AnnualTarget / periodDivider;
            outlay.PeriodBudget = outlay.ComponentBudget / periodDivider;
        }

        var componentThreeOutlays =
            await _outlayPersistence.GetOutlayDashAsync(request.Tenant, request.Region, "03", runner.CopYear);

        foreach (var outlay in componentThreeOutlays)
        {
            outlay.PeriodTarget = outlay.AnnualTarget / periodDivider;
            outlay.PeriodBudget = outlay.ComponentBudget / periodDivider;
        }

        var componentFourOutlays =
            await _outlayPersistence.GetOutlayDashAsync(request.Tenant, request.Region, "04", runner.CopYear);

        foreach (var outlay in componentFourOutlays)
        {
            outlay.PeriodTarget = outlay.AnnualTarget / periodDivider;
            outlay.PeriodBudget = outlay.ComponentBudget / periodDivider;
        }

        var totalOutlays = componentOneOutlays.Concat(componentTwoOutlays).Concat(componentThreeOutlays)
            .Concat(componentFourOutlays).ToArray();

        foreach (var outlay in totalOutlays)
        {
            outlay.PeriodTarget = Math.Round(outlay.PeriodTarget, 0);
            outlay.PeriodBudget = Math.Round(outlay.PeriodBudget, 0);
            outlay.AnnualTarget = Math.Round(outlay.AnnualTarget, 0);
            outlay.ComponentTarget = Math.Round(outlay.ComponentTarget, 0);
            outlay.PeriodAchievement = Math.Round(outlay.PeriodAchievement, 0);
            outlay.ComponentBudget = Math.Round(outlay.ComponentBudget, 0);
            outlay.PeriodExpenditure = Math.Round(outlay.PeriodExpenditure, 0);
        }

        return totalOutlays;
    }
}