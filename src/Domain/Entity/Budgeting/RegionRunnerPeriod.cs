using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class RegionRunnerPeriod : IIdentifiableEntity
{
    public string Tenant { get; set; }
    public string Runner { get; set; }
    public string Region { get; set; }
    public DateTime CreatedOn { get; set; }
}