using System.Collections.Generic;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Report;

public interface IActivityPlanReport
{
        byte[] Generate(List<ActivityPlanVm> activityPlans);
}
