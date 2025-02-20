using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearSite.Queries;

public class CopYearSitesQueryHandler : RequestHandlerBase, IRequestHandler<CopYearSitesQuery, CopYearSiteVm[]>
{
    private readonly ICopYearSiteService _copYearSiteService;

    public CopYearSitesQueryHandler(ICopYearSiteService copYearSiteService)
    {
        _copYearSiteService = copYearSiteService;
    }

    public async Task<CopYearSiteVm[]> Handle(CopYearSitesQuery request, CancellationToken cancellationToken) => 
        await _copYearSiteService.GetAllAsync(true);
}
