using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SiteType.Queries;

public class SiteTypesQueryHandler : RequestHandlerBase, IRequestHandler<SiteTypesQuery, SiteTypeVm[]>
{
    private readonly ISiteTypeService _siteTypeService;

    public SiteTypesQueryHandler(ISiteTypeService siteTypeService)
    {
        _siteTypeService = siteTypeService;
    }

    public async Task<SiteTypeVm[]> Handle(SiteTypesQuery request, CancellationToken cancellationToken) => 
        await _siteTypeService.GetAllAsync(true);
}
