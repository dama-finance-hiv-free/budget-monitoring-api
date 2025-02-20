using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class SurgeActivityVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public DateTime CreatedOn { get; set; }
}