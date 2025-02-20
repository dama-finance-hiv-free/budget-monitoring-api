using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearSite.Queries;

public class CopYearSiteQueryHandler : RequestHandlerBase, IRequestHandler<CopYearSiteQuery, CopYearSiteVm>
{
    private readonly ICopYearSiteService _copYearSiteService;

    public CopYearSiteQueryHandler(ICopYearSiteService copYearSiteService)
    {
        _copYearSiteService = copYearSiteService;
    }

    public async Task<CopYearSiteVm> Handle(CopYearSiteQuery request, CancellationToken cancellationToken) =>
        await _copYearSiteService.GetAsync(request.Tenant, request.Project);
}