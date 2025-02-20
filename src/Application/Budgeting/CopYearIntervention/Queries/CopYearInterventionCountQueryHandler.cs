using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearIntervention.Queries;

public class CopYearInterventionCountQueryHandler : RequestHandlerBase, IRequestHandler<CopYearInterventionCountQuery, int>
{
    private readonly ICopYearInterventionService _copYearInterventionService;

    public CopYearInterventionCountQueryHandler(ICopYearInterventionService copYearInterventionService)
    {
        _copYearInterventionService = copYearInterventionService;
    }

    public async Task<int> Handle(CopYearInterventionCountQuery request, CancellationToken cancellationToken) =>
        await _copYearInterventionService.GetCount(true);
}