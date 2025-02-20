using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class RunnerPeriodComponentBase : IIdentifiableEntity
{
    public string Tenant { get; set; }
    public string RunnerPeriod { get; set; }
    public string Project { get; set; }
    public string Component { get; set; }
    public DateTime CreatedOn { get; set; }
}