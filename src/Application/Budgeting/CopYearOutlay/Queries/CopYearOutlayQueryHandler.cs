using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearOutlay.Queries;

public class CopYearOutlayQueryHandler : RequestHandlerBase, IRequestHandler<CopYearOutlayQuery, CopYearOutlayVm>
{
    private readonly ICopYearOutlayService _copYearOutlayService;

    public CopYearOutlayQueryHandler(ICopYearOutlayService copYearOutlayService)
    {
        _copYearOutlayService = copYearOutlayService;
    }

    public async Task<CopYearOutlayVm> Handle(CopYearOutlayQuery request, CancellationToken cancellationToken) =>
        await _copYearOutlayService.GetAsync(request.Tenant, request.CopYear);
}