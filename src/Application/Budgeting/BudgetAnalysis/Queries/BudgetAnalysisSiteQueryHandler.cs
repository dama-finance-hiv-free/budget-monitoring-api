using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetAnalysis.Queries;

public class BudgetAnalysisSiteQueryHandler : RequestHandlerBase, IRequestHandler<BudgetAnalysisSiteQuery, BudgetAnalysisVm[]>
{
    private readonly IBudgetAnalysisService _budgetAnalysisService;

    public BudgetAnalysisSiteQueryHandler(IBudgetAnalysisService budgetAnalysisService)
    {
        _budgetAnalysisService = budgetAnalysisService;
    }

    public async Task<BudgetAnalysisVm[]> Handle(BudgetAnalysisSiteQuery request,
        CancellationToken cancellationToken) =>
        await _budgetAnalysisService.GetBudgetAnalysisSiteAsync(request.Options);
}
