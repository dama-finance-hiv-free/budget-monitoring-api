using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SurgeActivity.Commands;

public abstract class SurgeActivityCommand : IRequest<SurgeActivityCommandResponse>
{
    public SurgeActivityVm SurgeActivity { get; set; }
}