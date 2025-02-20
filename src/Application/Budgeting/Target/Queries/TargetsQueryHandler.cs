using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Target.Queries;

public class TargetsQueryHandler : RequestHandlerBase, IRequestHandler<TargetsQuery, TargetVm[]>
{
    private readonly ITargetService _targetService;

    public TargetsQueryHandler(ITargetService targetService)
    {
        _targetService = targetService;
    }

    public async Task<TargetVm[]> Handle(TargetsQuery request, CancellationToken cancellationToken) =>
        await _targetService.GetTargetsAsync(request.Tenant, request.Region);
}
