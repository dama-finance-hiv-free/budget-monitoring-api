using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class Site : ITenant
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string Region { get; set; }
    public string Description { get; set; }
    public string District { get; set; }
    public string SiteType { get; set; }
    public string SiteTier { get; set; }
    public DateTime CreatedOn { get; set; }
}