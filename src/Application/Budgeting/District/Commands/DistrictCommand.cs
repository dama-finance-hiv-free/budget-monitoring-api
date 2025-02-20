using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.District.Commands;

public abstract class DistrictCommand : IRequest<DistrictCommandResponse>
{
    public DistrictVm District { get; set; }
}