namespace Dama.Fin.Domain.Vm.Budgeting;

public class OutlayDashboardVm
{
    public OutlayCompareVm[] OutlayTargetsCompare { get; set; }
    public OutlayCompareVm[] OutlayBudgetsCompare { get; set; }
    public OutlayAnalysisVm[] ZoneOutlays { get; set; }
    public OutlayAnalysisVm[] RegionOutlaysYear { get; set; }
    public OutlayAnalysisVm[] RegionOutlaysComponent { get; set; }
    public OutlayAnalysisVm[] RegionOutlaysMonth { get; set; }
    public OutlayAnalysisVm[] RegionOutlaysWeek { get; set; }
}