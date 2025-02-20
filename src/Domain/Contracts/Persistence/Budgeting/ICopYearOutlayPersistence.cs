using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface ICopYearOutlayPersistence : IDataPersistence<CopYearOutlay>
{
   Task<CopYearOutlay[]> GetCopYearOutlaysAsync(string tenant);
    /* RepositoryActionResult<CopYearOutlay> SaveCopYearOutlayAsync(CopYearOutlay copYearOutlay);
    RepositoryActionResult<CopYearOutlay> DeleteCopYearOutlayAsync(string copYearOutlay);
    Task<RepositoryActionResult<CopYearOutlay>> OpenSessionAsync(CopYearOutlay copYearOutlay, string status);*/
}
