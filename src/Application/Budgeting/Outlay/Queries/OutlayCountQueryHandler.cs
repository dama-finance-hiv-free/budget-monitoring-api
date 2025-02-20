using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Queries;

public class OutlayCountQueryHandler : RequestHandlerBase, IRequestHandler<OutlayCountQuery, int>
{
    private readonly IOutlayService _outlayService;

    public OutlayCountQueryHandler(IOutlayService outlayService)
    {
        _outlayService = outlayService;
    }

    public async Task<int> Handle(OutlayCountQuery request, CancellationToken cancellationToken) =>
        await _outlayService.GetCount(true);
}