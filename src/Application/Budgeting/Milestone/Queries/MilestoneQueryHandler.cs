using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Milestone.Queries;

public class MilestoneQueryHandler : RequestHandlerBase, IRequestHandler<MilestoneQuery, MilestoneVm>
{
    private readonly IMilestoneService _milestoneService;

    public MilestoneQueryHandler(IMilestoneService milestoneService)
    {
        _milestoneService = milestoneService;
    }

    public async Task<MilestoneVm> Handle(MilestoneQuery request, CancellationToken cancellationToken) =>
        await _milestoneService.GetAsync(request.Tenant, request.Runner);
}