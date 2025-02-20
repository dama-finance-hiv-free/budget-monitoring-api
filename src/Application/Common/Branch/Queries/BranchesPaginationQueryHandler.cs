using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Branch.Queries;

public class BranchesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<BranchesPaginationQuery, BranchVm[]>
{
    private readonly IBranchService _branchService;

    public BranchesPaginationQueryHandler(IBranchService branchService)
    {
        _branchService = branchService;
    }

    public async Task<BranchVm[]> Handle(BranchesPaginationQuery request, CancellationToken cancellationToken) =>
        await _branchService.GetAllAsync(true, request.Page, request.Count);
}
