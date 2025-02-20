using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Milestone.Queries;

public class MilestoneCountQueryHandler : RequestHandlerBase, IRequestHandler<MilestoneCountQuery, int>
{
    private readonly IMilestoneService _milestoneService;

    public MilestoneCountQueryHandler(IMilestoneService milestoneService)
    {
        _milestoneService = milestoneService;
    }

    public async Task<int> Handle(MilestoneCountQuery request, CancellationToken cancellationToken) =>
        await _milestoneService.GetCount(true);
}