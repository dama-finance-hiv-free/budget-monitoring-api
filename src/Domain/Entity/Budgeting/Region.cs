using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class Region : IIdentifiableEntity
{
    public string Code { get; set; }
    public string Zone { get; set; }
    public string Initial { get; set; }
    public string Description { get; set; }
}