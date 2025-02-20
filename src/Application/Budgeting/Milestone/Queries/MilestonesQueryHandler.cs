using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Milestone.Queries;

public class MilestonesQueryHandler : RequestHandlerBase, IRequestHandler<MilestonesQuery, MilestoneVm[]>
{
    private readonly IMilestoneService _milestoneService;

    public MilestonesQueryHandler(IMilestoneService milestoneService)
    {
        _milestoneService = milestoneService;
    }

    public async Task<MilestoneVm[]> Handle(MilestonesQuery request, CancellationToken cancellationToken) => 
        await _milestoneService.GetAllAsync(true);
}
