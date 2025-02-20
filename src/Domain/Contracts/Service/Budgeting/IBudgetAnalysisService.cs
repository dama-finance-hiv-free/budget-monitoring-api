using System;
using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IBudgetAnalysisService: IDisposable
{
    Task<BudgetAnalysisVm[]> GetBudgetAnalysisCostCategoryAsync(BudgetAnalysisOptions tenant);
    Task<BudgetAnalysisVm[]> GetBudgetAnalysisInterventionAsync(BudgetAnalysisOptions options);
    Task<BudgetAnalysisVm[]> GetBudgetAnalysisSiteAsync(BudgetAnalysisOptions options);
}