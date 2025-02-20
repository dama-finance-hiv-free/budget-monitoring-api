using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Site.Queries;

public class SitesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<SitesPaginationQuery, SiteVm[]>
{
    private readonly ISiteService _siteService;

    public SitesPaginationQueryHandler(ISiteService siteService)
    {
        _siteService = siteService;
    }

    public async Task<SiteVm[]> Handle(SitesPaginationQuery request, CancellationToken cancellationToken) =>
        await _siteService.GetAllAsync(true, request.Page, request.Count);
}
