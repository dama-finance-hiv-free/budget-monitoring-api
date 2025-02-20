using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Component.Queries;

public class ComponentQueryHandler : RequestHandlerBase, IRequestHandler<ComponentQuery, ComponentVm>
{
    private readonly IComponentService _componentService;

    public ComponentQueryHandler(IComponentService componentService)
    {
        _componentService = componentService;
    }

    public async Task<ComponentVm> Handle(ComponentQuery request, CancellationToken cancellationToken) =>
        await _componentService.GetAsync(request.Tenant, request.Code);
}