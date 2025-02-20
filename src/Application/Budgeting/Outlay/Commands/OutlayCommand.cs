using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Commands;

public abstract class OutlayCommand : IRequest<OutlayCommandResponse>
{
    public OutlayVm Outlay { get; set; }
}