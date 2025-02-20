using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IZonePersistence : IDataPersistence<Zone>
{
    Task<Zone[]> GetZonesAsync(string tenant);
    /*RepositoryActionResult<Zone> SaveZoneAsync(Zone zone);
    RepositoryActionResult<Zone> DeleteZoneAsync(string zone);
    Task<RepositoryActionResult<Zone>> OpenSessionAsync(Zone zone, string status);*/
}
