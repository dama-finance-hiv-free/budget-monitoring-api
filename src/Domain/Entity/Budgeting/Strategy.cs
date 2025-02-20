using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class Strategy : ITenant
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
}