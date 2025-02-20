using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Site.Commands;

public abstract class SiteCommand : IRequest<SiteCommandResponse>
{
    public SiteVm Site { get; set; }
}