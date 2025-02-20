using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetAnalysis.Queries;

public class BudgetAnalysisCostCategoryQuery : IRequest<BudgetAnalysisVm[]>
{
    public BudgetAnalysisOptions Options { get; set; }
}