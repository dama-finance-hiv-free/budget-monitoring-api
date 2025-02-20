using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Domain.Contracts.Persistence.Common;

public interface ISystemMenuPersistence : IDataPersistence<SystemMenu>
{
    Task<SystemMenu[]> GetSystemMenusAsync(string lid);
}