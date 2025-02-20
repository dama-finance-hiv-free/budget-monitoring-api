using System.Collections.Generic;
using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Report;

public interface IBudgetExecutionReport
{
    //byte[] Generate(BudgetExecutionVm[] budgetExecutionReport, Dictionary<string, string> parameters);
    //byte[] Generate(ReportFileVm[] budgetExecutions);
    Task<byte[]> GenerateAsync(List<BudgetExecutionVm> data, BudgetAnalysisOptions options);
}