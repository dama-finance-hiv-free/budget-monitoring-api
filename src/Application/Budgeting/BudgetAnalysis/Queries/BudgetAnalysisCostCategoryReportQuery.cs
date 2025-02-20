using Dama.Fin.Domain.Vm;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetAnalysis.Queries;
public class BudgetAnalysisCostCategoryReportQuery : IRequest<ReportFileVm>
{
   public BudgetAnalysisOptions Options { get; set; }
}
