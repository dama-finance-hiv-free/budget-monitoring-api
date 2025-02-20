using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IQuarterPersistence : IDataPersistence<Quarter>
{
    Task<Quarter[]> GetQuartersAsync(string tenant);
}