using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Component.Queries;

public class ComponentsPaginationQueryHandler : RequestHandlerBase, IRequestHandler<ComponentsPaginationQuery, ComponentVm[]>
{
    private readonly IComponentService _componentService;

    public ComponentsPaginationQueryHandler(IComponentService componentService)
    {
        _componentService = componentService;
    }

    public async Task<ComponentVm[]> Handle(ComponentsPaginationQuery request, CancellationToken cancellationToken) =>
        await _componentService.GetAllAsync(true, request.Page, request.Count);
}
