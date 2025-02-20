using System.Collections.Generic;
using System.Threading.Tasks;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Report;

public interface IMilestoneReport
{
    Task<byte[]> GenerateAsync(List<MilestoneDashboardVm> milestoneReport, MilestoneDasboardOptions Options);
}