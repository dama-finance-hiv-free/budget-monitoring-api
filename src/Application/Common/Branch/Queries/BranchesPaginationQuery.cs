using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Branch.Queries;

public class BranchesPaginationQuery : IRequest<BranchVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}