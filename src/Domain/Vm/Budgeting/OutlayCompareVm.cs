using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class OutlayCompareVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string BudgetCode { get; set; }
    public string Indicator { get; set; }
    public string Name { get; set; }
    public double Nw { get; set; }
    public double Sw { get; set; }
    public double We { get; set; }
}