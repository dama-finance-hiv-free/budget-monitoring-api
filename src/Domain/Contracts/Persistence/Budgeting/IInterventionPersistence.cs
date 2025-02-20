using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IInterventionPersistence : IDataPersistence<Intervention>
{
    Task<Intervention[]> GetInterventionsAsync(string tenant);
    /*RepositoryActionResult<Intervention> SaveInterventionAsync(Intervention intervention);
    RepositoryActionResult<Intervention> DeleteInterventionAsync(string intervention);
    Task<RepositoryActionResult<Intervention>> OpenSessionAsync(Intervention intervention, string status);*/
}
