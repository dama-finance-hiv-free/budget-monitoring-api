using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface ITargetPersistence : IDataPersistence<Target>
{
   Task<Target[]> GetTargetsAsync(string tenant, string region);
}
