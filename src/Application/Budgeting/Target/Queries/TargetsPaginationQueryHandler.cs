using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Target.Queries;

public class TargetsPaginationQueryHandler : RequestHandlerBase, IRequestHandler<TargetsPaginationQuery, TargetVm[]>
{
    private readonly ITargetService _targetService;

    public TargetsPaginationQueryHandler(ITargetService targetService)
    {
        _targetService = targetService;
    }

    public async Task<TargetVm[]> Handle(TargetsPaginationQuery request, CancellationToken cancellationToken) =>
        await _targetService.GetAllAsync(true, request.Page, request.Count);
}
