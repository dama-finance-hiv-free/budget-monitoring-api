using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class UserCoordination : IIdentifiableEntity
{
    public string User { get; set; }
    public string Coordination { get; set; }
    public DateTime CreatedOn { get; set; }
}