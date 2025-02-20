using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class IncludeRunner : IIdentifiableEntity
{
    public string User { get; set; }
    public string Runner { get; set; }
}