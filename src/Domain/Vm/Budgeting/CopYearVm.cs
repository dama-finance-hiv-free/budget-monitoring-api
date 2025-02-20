using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class CopYearVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    public DateTime CreatedOn { get; set; }
}