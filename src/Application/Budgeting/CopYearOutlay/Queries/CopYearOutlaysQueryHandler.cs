using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearOutlay.Queries;

public class CopYearOutlaysQueryHandler : RequestHandlerBase, IRequestHandler<CopYearOutlaysQuery, CopYearOutlayVm[]>
{
    private readonly ICopYearOutlayService _copYearOutlayService;

    public CopYearOutlaysQueryHandler(ICopYearOutlayService copYearOutlayService)
    {
        _copYearOutlayService = copYearOutlayService;
    }

    public async Task<CopYearOutlayVm[]> Handle(CopYearOutlaysQuery request, CancellationToken cancellationToken) => 
        await _copYearOutlayService.GetAllAsync(true);
}
