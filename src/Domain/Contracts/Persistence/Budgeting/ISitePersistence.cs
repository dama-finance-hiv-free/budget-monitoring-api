using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface ISitePersistence : IDataPersistence<Site>
{
    Task<Site[]> GetSitesAsync(string tenant);
    Task<Site[]> GetSitesAsync(string tenant, string region);
}
