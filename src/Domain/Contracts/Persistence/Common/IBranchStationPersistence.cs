using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Domain.Contracts.Persistence.Common;

public interface IBranchStationPersistence : IDataPersistence<BranchStation>
{
  //  Task<BranchStation[]> GetUserBranchStationsAsync(string tenant, string user);
}