using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.Milestone;

public class MilestoneService : ServiceBase<Domain.Entity.Budgeting.Milestone, MilestoneVm>, IMilestoneService
{
    private readonly IMilestonePersistence _milestonePersistence;
    private readonly IMapper _mapper;

    public MilestoneService(IDataPersistence<Domain.Entity.Budgeting.Milestone> persistence, IMapper mapper,
        IDistributedCache cache, IMilestonePersistence milestonePersistence) : base(persistence, mapper, cache)
    {
        _milestonePersistence = milestonePersistence;
        _mapper = mapper;
    }

    public async Task<MilestoneVm[]> GetMilestonesAsync(string tenant)
    {
        var milestones = await _milestonePersistence.GetMilestonesAsync(tenant);
        return  _mapper.Map<MilestoneVm[]>(milestones);
    }
}