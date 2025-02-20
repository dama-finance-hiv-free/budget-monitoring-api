using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Site.Queries;

public class SiteCountQueryHandler : RequestHandlerBase, IRequestHandler<SiteCountQuery, int>
{
    private readonly ISiteService _siteService;

    public SiteCountQueryHandler(ISiteService siteService)
    {
        _siteService = siteService;
    }

    public async Task<int> Handle(SiteCountQuery request, CancellationToken cancellationToken) =>
        await _siteService.GetCount(true);
}