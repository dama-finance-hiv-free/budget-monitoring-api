using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Intervention.Queries;

public class InterventionQueryHandler : RequestHandlerBase, IRequestHandler<InterventionQuery, InterventionVm>
{
    private readonly IInterventionService _interventionService;

    public InterventionQueryHandler(IInterventionService interventionService)
    {
        _interventionService = interventionService;
    }

    public async Task<InterventionVm> Handle(InterventionQuery request, CancellationToken cancellationToken) =>
        await _interventionService.GetAsync(request.Tenant, request.Code);
}