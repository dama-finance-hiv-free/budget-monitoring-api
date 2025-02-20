using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SiteType.Queries;

public class SiteTypeCountQueryHandler : RequestHandlerBase, IRequestHandler<SiteTypeCountQuery, int>
{
    private readonly ISiteTypeService _siteTypeService;

    public SiteTypeCountQueryHandler(ISiteTypeService siteTypeService)
    {
        _siteTypeService = siteTypeService;
    }

    public async Task<int> Handle(SiteTypeCountQuery request, CancellationToken cancellationToken) =>
        await _siteTypeService.GetCount(true);
}