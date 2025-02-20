using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Component.Queries;

public class ComponentCountQueryHandler : RequestHandlerBase, IRequestHandler<ComponentCountQuery, int>
{
    private readonly IComponentService _componentService;

    public ComponentCountQueryHandler(IComponentService componentService)
    {
        _componentService = componentService;
    }
    public async Task<int> Handle(ComponentCountQuery request, CancellationToken cancellationToken) =>
        await _componentService.GetCount(true);
}