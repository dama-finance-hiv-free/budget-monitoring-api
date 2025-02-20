using System.Collections.Generic;
using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Report;

public interface IOutlayAnalysisReport
{
    Task<byte[]> GenerateAsync(List<OutlayDashVm> outlayAnalysisReport, BudgetAnalysisOptions options);
}