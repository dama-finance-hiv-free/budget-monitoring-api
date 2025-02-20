using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Town.Commands;

public abstract class TownCommand : IRequest<TownCommandResponse>
{
    public TownVm Town { get; set; }
}