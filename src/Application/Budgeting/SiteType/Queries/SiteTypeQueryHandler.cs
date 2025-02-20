using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SiteType.Queries;

public class SiteTypeQueryHandler : RequestHandlerBase, IRequestHandler<SiteTypeQuery, SiteTypeVm>
{
    private readonly ISiteTypeService _sitetypeService;

    public SiteTypeQueryHandler(ISiteTypeService sitetypeService)
    {
        _sitetypeService = sitetypeService;
    }

    public async Task<SiteTypeVm> Handle(SiteTypeQuery request, CancellationToken cancellationToken) =>
        await _sitetypeService.GetAsync(request.Code, request.Code);
}