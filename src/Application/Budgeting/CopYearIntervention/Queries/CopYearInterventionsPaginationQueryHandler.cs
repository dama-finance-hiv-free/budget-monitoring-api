using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearIntervention.Queries;

public class CopYearInterventionsPaginationQueryHandler : RequestHandlerBase, IRequestHandler<CopYearInterventionsPaginationQuery, CopYearInterventionVm[]>
{
    private readonly ICopYearInterventionService _copYearInterventionService;

    public CopYearInterventionsPaginationQueryHandler(ICopYearInterventionService copYearInterventionService)
    {
        _copYearInterventionService = copYearInterventionService;
    }

    public async Task<CopYearInterventionVm[]> Handle(CopYearInterventionsPaginationQuery request, CancellationToken cancellationToken) =>
        await _copYearInterventionService.GetAllAsync(true, request.Page, request.Count);
}
