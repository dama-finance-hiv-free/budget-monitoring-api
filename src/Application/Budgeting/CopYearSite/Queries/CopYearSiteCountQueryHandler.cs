using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearSite.Queries;

public class CopYearSiteCountQueryHandler : RequestHandlerBase, IRequestHandler<CopYearSiteCountQuery, int>
{
    private readonly ICopYearSiteService _copYearSiteService;

    public CopYearSiteCountQueryHandler(ICopYearSiteService copYearSiteService)
    {
        _copYearSiteService = copYearSiteService;
    }

    public async Task<int> Handle(CopYearSiteCountQuery request, CancellationToken cancellationToken) =>
        await _copYearSiteService.GetCount(true);
}