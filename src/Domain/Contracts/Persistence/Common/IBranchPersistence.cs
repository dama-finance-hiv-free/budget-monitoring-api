using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Domain.Contracts.Persistence.Common;

public interface IBranchPersistence : IDataPersistence<Branch>
{
    Task<Branch[]> GetUserBranchesAsync(string tenant, string user);
    Task<string[]> GetBranchCodesAsync();
    Task<Branch[]> GetBranchesAsync(string tenant);
    Task<Branch> GetBranchAsync(string tenant, string code);
}
