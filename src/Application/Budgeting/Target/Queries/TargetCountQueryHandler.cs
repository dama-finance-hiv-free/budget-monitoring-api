using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Target.Queries;

public class TargetCountQueryHandler : RequestHandlerBase, IRequestHandler<TargetCountQuery, int>
{
    private readonly ITargetService _targetService;

    public TargetCountQueryHandler(ITargetService targetService)
    {
        _targetService = targetService;
    }

    public async Task<int> Handle(TargetCountQuery request, CancellationToken cancellationToken) =>
        await _targetService.GetCount(true);
}