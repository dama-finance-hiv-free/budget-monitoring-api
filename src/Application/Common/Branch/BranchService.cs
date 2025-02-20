using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Common.Branch;

public class BranchService : ServiceBase<Domain.Entity.Common.Branch, BranchVm>, IBranchService
{
    private readonly IBranchPersistence _branchPersistence;
    private readonly IMapper _mapper;

    public BranchService(IDataPersistence<Domain.Entity.Common.Branch> persistence, IMapper mapper,
        IDistributedCache cache, IBranchPersistence branchPersistence) : base(persistence, mapper, cache)
    {
        _branchPersistence = branchPersistence;
        _mapper = mapper;
    }

    public async Task<BranchVm[]> GetUserBranchesAsync(string tenant, string user)
    {
        var branches = await _branchPersistence.GetUserBranchesAsync(tenant, user);
        return  _mapper.Map<BranchVm[]>(branches);
    }

    public async Task<BranchVm[]> GetBranchesAsync(string tenant)
        => await GetCachedItemsAsync(() => _branchPersistence.GetBranchesAsync(tenant));
        

    public async Task<string[]> GetBranchCodesAsync(string tenant)
    {
        var branchCodes = await GetBranchesAsync(tenant);
        return branchCodes.Select(x => x.Code).ToArray();

    }

}