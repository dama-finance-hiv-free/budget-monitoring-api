using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IComponentActivityPersistence : IDataPersistence<ComponentActivity>
{
    Task<string[]> GetComponentActivityCodesAsync(string tenant, string copYear, string component);
}