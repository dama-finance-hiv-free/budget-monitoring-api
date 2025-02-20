using Dama.Fin.Domain.Vm;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetExecution.Queries;

public class BudgetExecutionReportQuery : IRequest<ReportFileVm>
{
    public BudgetAnalysisOptions Options { get; set; }
}