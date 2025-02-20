using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Queries;

public class OutlayQueryHandler : RequestHandlerBase, IRequestHandler<OutlayQuery, OutlayVm>
{
    private readonly IOutlayService _outlayService;

    public OutlayQueryHandler(IOutlayService outlayService)
    {
        _outlayService = outlayService;
    }

    public async Task<OutlayVm> Handle(OutlayQuery request, CancellationToken cancellationToken) =>
        await _outlayService.GetAsync(request.Tenant, request.Code);
}