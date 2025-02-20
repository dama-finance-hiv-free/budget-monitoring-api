using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Branch.Commands;

public abstract class BranchCommand : IRequest<BranchCommandResponse>
{
    public BranchVm Branch { get; set; }
}