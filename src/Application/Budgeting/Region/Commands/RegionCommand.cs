using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Region.Commands;

public abstract class RegionCommand : IRequest<RegionCommandResponse>
{
    public RegionVm Region { get; set; }
}