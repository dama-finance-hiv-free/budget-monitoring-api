using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetAnalysis.Queries;

public class BudgetAnalysisCostCategoryQueryHandler : RequestHandlerBase,
    IRequestHandler<BudgetAnalysisCostCategoryQuery, BudgetAnalysisVm[]>
{
    private readonly IBudgetAnalysisService _budgetAnalysisService;

    public BudgetAnalysisCostCategoryQueryHandler(IBudgetAnalysisService budgetAnalysisService)
    {
        _budgetAnalysisService = budgetAnalysisService;
    }

    public async Task<BudgetAnalysisVm[]> Handle(BudgetAnalysisCostCategoryQuery request,
        CancellationToken cancellationToken) =>
        await _budgetAnalysisService.GetBudgetAnalysisCostCategoryAsync(request.Options);

}
