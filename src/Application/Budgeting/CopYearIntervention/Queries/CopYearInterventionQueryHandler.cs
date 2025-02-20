using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearIntervention.Queries;

public class CopYearInterventionQueryHandler : RequestHandlerBase, IRequestHandler<CopYearInterventionQuery, CopYearInterventionVm>
{
    private readonly ICopYearInterventionService _copYearInterventionService;

    public CopYearInterventionQueryHandler(ICopYearInterventionService copYearInterventionService)
    {
        _copYearInterventionService = copYearInterventionService;
    }

    public async Task<CopYearInterventionVm> Handle(CopYearInterventionQuery request, CancellationToken cancellationToken) =>
        await _copYearInterventionService.GetAsync(request.Tenant, request.CopYear);
}