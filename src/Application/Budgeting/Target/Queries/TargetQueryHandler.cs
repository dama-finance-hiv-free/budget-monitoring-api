using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Target.Queries;

public class TargetQueryHandler : RequestHandlerBase, IRequestHandler<TargetQuery, TargetVm>
{
    private readonly ITargetService _targetService;

    public TargetQueryHandler(ITargetService targetService)
    {
        _targetService = targetService;
    }

    public async Task<TargetVm> Handle(TargetQuery request, CancellationToken cancellationToken) =>
        await _targetService.GetAsync(request.Tenant, request.CopYear);
}