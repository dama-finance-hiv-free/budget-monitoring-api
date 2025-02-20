using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IComponentPersistence : IDataPersistence<Component>
{
    Task<Component[]> GetComponentsAsync(string tenant);
}