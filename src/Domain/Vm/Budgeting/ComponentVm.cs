using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class ComponentVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string CopYear { get; set; }
    public string Project { get; set; }
    public string Description { get; set; }
    public string LongDescription { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}