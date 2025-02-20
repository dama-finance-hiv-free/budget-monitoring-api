using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetAnalysis.Queries;

public class BudgetAnalysisSiteQuery : IRequest<BudgetAnalysisVm[]>
{
    public BudgetAnalysisOptions Options { get; set; }
}