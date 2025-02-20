using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Report;

public interface IActivityScheduleBudgetReport
{
    byte[] Generate(ActivityScheduleReportVm activityScheduleReport);
}