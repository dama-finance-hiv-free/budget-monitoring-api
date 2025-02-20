using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Branch.Queries;

public class BranchQuery : IRequest<BranchVm>
{
    public string Tenant { get; set; }
    public string Code { get; set; }
}