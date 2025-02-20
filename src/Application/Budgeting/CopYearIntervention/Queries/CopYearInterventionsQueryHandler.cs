using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearIntervention.Queries;

public class CopYearInterventionsQueryHandler : RequestHandlerBase, IRequestHandler<CopYearInterventionsQuery, CopYearInterventionVm[]>
{
    private readonly ICopYearInterventionService _copYearInterventionService;

    public CopYearInterventionsQueryHandler(ICopYearInterventionService copYearInterventionService)
    {
        _copYearInterventionService = copYearInterventionService;
    }

    public async Task<CopYearInterventionVm[]> Handle(CopYearInterventionsQuery request, CancellationToken cancellationToken) => 
        await _copYearInterventionService.GetAllAsync(true);
}
