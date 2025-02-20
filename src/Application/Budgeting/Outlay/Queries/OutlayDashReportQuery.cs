using Dama.Fin.Domain.Vm;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Queries;

public class OutlayDashReportQuery : IRequest<ReportFileVm>
{
    public BudgetAnalysisOptions Options { get; set; }
}
