using System;
using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Core.Common.Helpers;

namespace Dama.Fin.Domain.Contracts.Service;

public interface IServiceBase<TModel> : IDisposable where TModel : class, IEntityBase, new()
{
    Task<TModel[]> GetAllAsync(bool bypassCache);
    Task<int> GetCount(bool bypassCache);
    Task<TModel[]> GetAllAsync(bool bypassCache, int page, int count);
    Task<RepositoryActionResult<TModel>> AddAsync(TModel model);
    Task<RepositoryActionResult<TModel>> EditAsync(TModel model);
    Task<RepositoryActionResult<TModel>> DeleteAsync(TModel model);
    Task<TModel> GetAsync(string tenant, string code);
}