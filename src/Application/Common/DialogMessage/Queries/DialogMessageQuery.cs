using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.DialogMessage.Queries;

public class DialogMessageQuery : IRequest<DialogMessageVm>
{
    public string Tenant { get; set; }
    public string Code { get; set; }
}