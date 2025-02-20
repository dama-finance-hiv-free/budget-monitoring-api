using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Queries;

public class OutlaysQueryHandler : RequestHandlerBase, IRequestHandler<OutlaysQuery, OutlayVm[]>
{
    private readonly IOutlayService _outlayService;

    public OutlaysQueryHandler(IOutlayService outlayService)
    {
        _outlayService = outlayService;
    }

    public async Task<OutlayVm[]> Handle(OutlaysQuery request, CancellationToken cancellationToken) => 
        await _outlayService.GetAllAsync(true);
}