using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class OutlayVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string BudgetCode { get; set; }
    public string Indicator { get; set; }
    public string Type { get; set; }
    public DateTime CreatedOn { get; set; }
}