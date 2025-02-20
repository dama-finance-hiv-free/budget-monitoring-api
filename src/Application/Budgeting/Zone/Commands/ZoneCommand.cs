using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Zone.Commands;

public abstract class ZoneCommand : IRequest<ZoneCommandResponse>
{
    public ZoneVm Zone { get; set; }
}