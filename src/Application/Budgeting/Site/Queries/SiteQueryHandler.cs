using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Site.Queries;

public class SiteQueryHandler : RequestHandlerBase, IRequestHandler<SiteQuery, SiteVm>
{
    private readonly ISiteService _sitetypeService;

    public SiteQueryHandler(ISiteService sitetypeService)
    {
        _sitetypeService = sitetypeService;
    }

    public async Task<SiteVm> Handle(SiteQuery request, CancellationToken cancellationToken) =>
        await _sitetypeService.GetAsync(request.Tenant, request.Code);
}