using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetAnalysis.Queries;

public class BudgetAnalysisInterventionQueryHandler : RequestHandlerBase,
    IRequestHandler<BudgetAnalysisInterventionQuery, BudgetAnalysisVm[]>
{
    private readonly IBudgetAnalysisService _budgetAnalysisService;

    public BudgetAnalysisInterventionQueryHandler(IBudgetAnalysisService budgetAnalysisService)
    {
        _budgetAnalysisService = budgetAnalysisService;
    }

    public async Task<BudgetAnalysisVm[]> Handle(BudgetAnalysisInterventionQuery request,
        CancellationToken cancellationToken) =>
        await _budgetAnalysisService.GetBudgetAnalysisInterventionAsync(request.Options);
}
