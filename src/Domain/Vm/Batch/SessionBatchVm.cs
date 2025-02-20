using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Vm.Budgeting;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Domain.Vm.Batch;

public class SessionBatchVm: IEntityBase
{
    public string Tenant { get; set; }
    public string Branch { get; set; }
    public string UserCode { get; set; }
    public BranchVm[] Branches { get; set; }
    public ServerStatusVm[] ServerStatuses { get; set; }
    public UserMenuVm[] UserMenus { get; set; }
    public UserInfoVm User { get; set; }
    public RegionVm[] Regions { get; set; }
    public RunnerVm[] Runners { get; set; }
    public RunnerComponentVm[] RunnerComponents { get; set; }
}