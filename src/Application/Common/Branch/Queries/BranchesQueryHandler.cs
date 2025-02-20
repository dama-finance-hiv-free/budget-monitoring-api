using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Branch.Queries;

public class BranchesQueryHandler : RequestHandlerBase, IRequestHandler<BranchesQuery, BranchVm[]>
{
    private readonly IBranchService _branchService;

    public BranchesQueryHandler(IBranchService branchService)
    {
        _branchService = branchService;
    }

    public async Task<BranchVm[]> Handle(BranchesQuery request, CancellationToken cancellationToken) => 
        await _branchService.GetAllAsync(true);

}
