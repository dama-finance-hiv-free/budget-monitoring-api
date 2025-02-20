using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Intervention.Queries;

public class InterventionCountQueryHandler : RequestHandlerBase, IRequestHandler<InterventionCountQuery, int>
{
    private readonly IInterventionService _interventionService;

    public InterventionCountQueryHandler(IInterventionService interventionService)
    {
        _interventionService = interventionService;
    }

    public async Task<int> Handle(InterventionCountQuery request, CancellationToken cancellationToken) =>
        await _interventionService.GetCount(true);
}