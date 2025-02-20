using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Milestone.Commands;

public abstract class MilestoneCommand : IRequest<MilestoneCommandResponse>
{
    public MilestoneVm Milestone { get; set; }
}