using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SiteType.Commands;

public abstract class SiteTypeCommand : IRequest<SiteTypeCommandResponse>
{
    public SiteTypeVm SiteType { get; set; }
}