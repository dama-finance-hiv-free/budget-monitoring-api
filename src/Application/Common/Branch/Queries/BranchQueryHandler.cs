using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Branch.Queries;

public class BranchQueryHandler : RequestHandlerBase, IRequestHandler<BranchQuery, BranchVm>
{
    private readonly IBranchService _branchService;

    public BranchQueryHandler(IBranchService branchService)
    {
        _branchService = branchService;
    }

    public async Task<BranchVm> Handle(BranchQuery request, CancellationToken cancellationToken) =>
        await _branchService.GetAsync(request.Tenant, request.Code);
}