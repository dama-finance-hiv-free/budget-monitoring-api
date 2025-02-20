using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class SiteType : IIdentifiableEntity
{
    public string Code { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
}