using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class RegionRunnerPeriodVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Runner { get; set; }
    public string Region { get; set; }
    public DateTime CreatedOn { get; set; }
}