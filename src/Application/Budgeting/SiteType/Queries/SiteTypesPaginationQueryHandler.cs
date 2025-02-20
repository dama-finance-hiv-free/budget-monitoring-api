using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SiteType.Queries;

public class SiteTypesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<SiteTypesPaginationQuery, SiteTypeVm[]>
{
    private readonly ISiteTypeService _siteTypeService;

    public SiteTypesPaginationQueryHandler(ISiteTypeService siteTypeService)
    {
        _siteTypeService = siteTypeService;
    }

    public async Task<SiteTypeVm[]> Handle(SiteTypesPaginationQuery request, CancellationToken cancellationToken) =>
        await _siteTypeService.GetAllAsync(true, request.Page, request.Count);
}
