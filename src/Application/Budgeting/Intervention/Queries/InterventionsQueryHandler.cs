using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Intervention.Queries;

public class InterventionsQueryHandler : RequestHandlerBase, IRequestHandler<InterventionsQuery, InterventionVm[]>
{
    private readonly IInterventionService _interventionService;

    public InterventionsQueryHandler(IInterventionService interventionService)
    {
        _interventionService = interventionService;
    }

    public async Task<InterventionVm[]> Handle(InterventionsQuery request, CancellationToken cancellationToken) => 
        await _interventionService.GetAllAsync(true);
}
