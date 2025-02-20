using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Milestone.Queries;

public class MilestonesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<MilestonesPaginationQuery, MilestoneVm[]>
{
    private readonly IMilestoneService _milestoneService;

    public MilestonesPaginationQueryHandler(IMilestoneService milestoneService)
    {
        _milestoneService = milestoneService;
    }

    public async Task<MilestoneVm[]> Handle(MilestonesPaginationQuery request, CancellationToken cancellationToken) =>
        await _milestoneService.GetAllAsync(true, request.Page, request.Count);
}
