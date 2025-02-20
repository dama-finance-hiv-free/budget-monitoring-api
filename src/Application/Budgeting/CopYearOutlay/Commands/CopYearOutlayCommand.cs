using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearOutlay.Commands;

public abstract class CopYearOutlayCommand : IRequest<CopYearOutlayCommandResponse>
{
    public CopYearOutlayVm CopYearOutlay { get; set; }
}