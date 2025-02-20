using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface ICopYearInterventionPersistence : IDataPersistence<CopYearIntervention>
{
    Task<CopYearIntervention[]> GetCopYearInterventionsAsync(string tenant);
    /*RepositoryActionResult<CopYearIntervention> SaveCopYearInterventionAsync(CopYearIntervention copYearIntervention);
    RepositoryActionResult<CopYearIntervention> DeleteCopYearInterventionAsync(string copYearIntervention);
    Task<RepositoryActionResult<CopYearIntervention>> OpenSessionAsync(CopYearIntervention copYearIntervention, string status);*/
}
