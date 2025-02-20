using System;
using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Domain.Contracts.Persistence.Common;

public interface IDateGenerationHistoryPersistence : IDataPersistence<DateGenerationHistory>
{
    Task<DateGenerationHistory[]> GetDateGenerationHistorysAsync(string tenant, string user);
    RepositoryActionResult<DateGenerationHistory> SaveDatGenAsync(DateGenerationHistory dateGeneration);
    RepositoryActionResult<DateGenerationHistory> DeleteDateGenerationHistoryAsync(string branch);
    Task<RepositoryActionResult<DateGenerationHistory>> OpenSessionAsync(DateGenerationHistory dateGeneration, string status);
    Task<DateTime> GetLastTransDateAsync(string branch, DateTime transDate);
    Task<bool> DateAlreadyUsedAsync(string branch, DateTime transDate);
}