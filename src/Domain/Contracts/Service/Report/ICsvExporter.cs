using System.Collections.Generic;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Report
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<ActivityPlanVm> activityPlans);
    }
}
