using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IDistrictPersistence : IDataPersistence<District>
{
   Task<District[]> GetDistrictsAsync(string tenant);
    /* RepositoryActionResult<District> SaveDistrictAsync(District district);
    RepositoryActionResult<District> DeleteDistrictAsync(string district);
    Task<RepositoryActionResult<District>> OpenSessionAsync(District district, string status);*/
}
