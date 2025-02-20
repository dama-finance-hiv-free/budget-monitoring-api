namespace Dama.Fin.Domain.Vm.Budgeting;

public class MilestoneDashboardVm : MilestoneVm
{
    public string InterventionCode { get; set; }
    public string InterventionName { get; set; }
    public string SiteName { get; set; }
    public string ActivityPlanDescription { get; set; }
}