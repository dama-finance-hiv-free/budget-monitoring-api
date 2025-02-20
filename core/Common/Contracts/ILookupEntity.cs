namespace Dama.Core.Common.Contracts;

public interface ILookupEntity : IEntityBase
{
    string SCode { get; }
    string SDescription { get; }
}