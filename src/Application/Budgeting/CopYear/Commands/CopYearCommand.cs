using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYear.Commands;

public abstract class CopYearCommand : IRequest<CopYearCommandResponse>
{
    public CopYearVm CopYear { get; set; }
}