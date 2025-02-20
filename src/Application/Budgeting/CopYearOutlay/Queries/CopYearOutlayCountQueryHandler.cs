using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearOutlay.Queries;

public class CopYearOutlayCountQueryHandler : RequestHandlerBase, IRequestHandler<CopYearOutlayCountQuery, int>
{
    private readonly ICopYearOutlayService _copYearOutlayService;

    public CopYearOutlayCountQueryHandler(ICopYearOutlayService copYearOutlayService)
    {
        _copYearOutlayService = copYearOutlayService;
    }

    public async Task<int> Handle(CopYearOutlayCountQuery request, CancellationToken cancellationToken) =>
        await _copYearOutlayService.GetCount(true);
}