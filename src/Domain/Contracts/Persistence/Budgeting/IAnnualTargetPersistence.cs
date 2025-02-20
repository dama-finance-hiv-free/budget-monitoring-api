using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IAnnualTargetPersistence : IDataPersistence<AnnualTarget>
{
   Task<AnnualTarget[]> GetAnnualTargetsAsync(string tenant);
    /* RepositoryActionResult<AnnualTarget> SaveAnnualTargetAsync(AnnualTarget annualTarget);
    RepositoryActionResult<AnnualTarget> DeleteAnnualTargetAsync(string annualTarget);
    Task<RepositoryActionResult<AnnualTarget>> OpenSessionAsync(AnnualTarget annualTarget, string status);*/
}
