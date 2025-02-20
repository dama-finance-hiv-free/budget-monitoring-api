using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class ProjectSite : ITenant
{
    public string Tenant { get; set; }
    public string copYear { get; set; }
    public string Project { get; set; }
    public string Site { get; set; }
    public DateTime CreatedOn { get; set; }
}