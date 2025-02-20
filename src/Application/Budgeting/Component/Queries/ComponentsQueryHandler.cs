using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Component.Queries;

public class ComponentsQueryHandler : RequestHandlerBase, IRequestHandler<ComponentsQuery, ComponentVm[]>
{
    private readonly IComponentService _componentService;

    public ComponentsQueryHandler(IComponentService componentService)
    {
        _componentService = componentService;
    }

    public async Task<ComponentVm[]> Handle(ComponentsQuery request, CancellationToken cancellationToken) => 
        await _componentService.GetAllAsync(true);
}
