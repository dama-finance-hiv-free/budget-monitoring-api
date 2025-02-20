using System.Collections.Generic;
using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Report;

public interface IBudgetAnalysisReport
{
    Task<byte[]> GenerateAsync(List<BudgetAnalysisVm> data, BudgetAnalysisOptions options);
}