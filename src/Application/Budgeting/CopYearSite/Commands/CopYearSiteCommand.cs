using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearSite.Commands;

public abstract class CopYearSiteCommand : IRequest<CopYearSiteCommandResponse>
{
    public CopYearSiteVm CopYearSite { get; set; }
}