using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Intervention.Queries;

public class InterventionsPaginationQueryHandler : RequestHandlerBase, IRequestHandler<InterventionsPaginationQuery, InterventionVm[]>
{
    private readonly IInterventionService _interventionService;

    public InterventionsPaginationQueryHandler(IInterventionService interventionService)
    {
        _interventionService = interventionService;
    }

    public async Task<InterventionVm[]> Handle(InterventionsPaginationQuery request, CancellationToken cancellationToken) =>
        await _interventionService.GetAllAsync(true, request.Page, request.Count);
}
