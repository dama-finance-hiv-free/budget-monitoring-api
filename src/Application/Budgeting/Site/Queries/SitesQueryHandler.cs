using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Site.Queries;

public class SitesQueryHandler : RequestHandlerBase, IRequestHandler<SitesQuery, SiteVm[]>
{
    private readonly ISiteService _siteService;

    public SitesQueryHandler(ISiteService siteService)
    {
        _siteService = siteService;
    }

    public async Task<SiteVm[]> Handle(SitesQuery request, CancellationToken cancellationToken) =>
        await _siteService.GetSitesAsync(request.Tenant, request.Region);
}
