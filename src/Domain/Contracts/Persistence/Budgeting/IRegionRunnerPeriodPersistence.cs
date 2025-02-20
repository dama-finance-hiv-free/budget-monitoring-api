using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IRegionRunnerPeriodPersistence : IDataPersistence<RegionRunnerPeriod>
{
    Task<RegionRunnerPeriod[]> GetRegionRunnerPeriodsAsync(string tenant);

   /*RepositoryActionResult<RegionRunnerPeriod> SaveRegionRunnerPeriodAsync(RegionRunnerPeriod regionRunnerPeriod);
   RepositoryActionResult<RegionRunnerPeriod> DeleteRegionRunnerPeriodAsync(string regionRunnerPeriod);
   Task<RepositoryActionResult<RegionRunnerPeriod>> OpenSessionAsync(RegionRunnerPeriod regionRunnerPeriod, string status);*/
}
