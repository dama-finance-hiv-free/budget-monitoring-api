using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.AnnualTarget.Queries;

public class AnnualTargetCountQueryHandler : RequestHandlerBase, IRequestHandler<AnnualTargetCountQuery, int>
{
    private readonly IAnnualTargetService _annualTargetService;

    public AnnualTargetCountQueryHandler(IAnnualTargetService annualTargetService)
    {
        _annualTargetService = annualTargetService;
    }

    public async Task<int> Handle(AnnualTargetCountQuery request, CancellationToken cancellationToken) =>
        await _annualTargetService.GetCount(true);
}