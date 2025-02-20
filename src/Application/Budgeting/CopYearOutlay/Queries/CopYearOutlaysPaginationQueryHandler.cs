using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearOutlay.Queries;

public class CopYearOutlaysPaginationQueryHandler : RequestHandlerBase, IRequestHandler<CopYearOutlaysPaginationQuery, CopYearOutlayVm[]>
{
    private readonly ICopYearOutlayService _copYearOutlayService;

    public CopYearOutlaysPaginationQueryHandler(ICopYearOutlayService copYearOutlayService)
    {
        _copYearOutlayService = copYearOutlayService;
    }

    public async Task<CopYearOutlayVm[]> Handle(CopYearOutlaysPaginationQuery request, CancellationToken cancellationToken) =>
        await _copYearOutlayService.GetAllAsync(true, request.Page, request.Count);
}
