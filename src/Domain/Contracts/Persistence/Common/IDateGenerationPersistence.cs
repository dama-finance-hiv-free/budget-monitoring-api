using System;
using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Domain.Contracts.Persistence.Common;

public interface IDateGenerationPersistence : IDataPersistence<DateGeneration>
{
    Task<DateGeneration[]> GetDateGenerationsAsync(string tenant);
    RepositoryActionResult<DateGeneration> SaveDatGenAsync(DateGeneration dateGeneration);
    RepositoryActionResult<DateGeneration> DeleteDateGenerationAsync(string branch);
    Task<DateTime> GetLastTransDateAsync(string branch, DateTime transDate);
    Task<bool> DateAlreadyUsedAsync(string branch, DateTime transDate);
}