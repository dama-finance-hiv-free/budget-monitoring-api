using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearSite.Queries;

public class CopYearSitesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<CopYearSitesPaginationQuery, CopYearSiteVm[]>
{
    private readonly ICopYearSiteService _copYearSiteService;

    public CopYearSitesPaginationQueryHandler(ICopYearSiteService copYearSiteService)
    {
        _copYearSiteService = copYearSiteService;
    }

    public async Task<CopYearSiteVm[]> Handle(CopYearSitesPaginationQuery request, CancellationToken cancellationToken) =>
        await _copYearSiteService.GetAllAsync(true, request.Page, request.Count);
}
