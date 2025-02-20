using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class CopYearSite : ITenant
{
    public string Tenant { get; set; }
    public string CopYear { get; set; }
    public string Site { get; set; }
}