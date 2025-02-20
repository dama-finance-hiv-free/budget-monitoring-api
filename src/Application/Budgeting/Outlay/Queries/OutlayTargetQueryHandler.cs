using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Queries;

public class OutlayTargetQueryHandler : RequestHandlerBase, IRequestHandler<OutlayTargetQuery, OutlayDashVm[]>
{
    private readonly IOutlayPersistence _outlayPersistence;

    public OutlayTargetQueryHandler(IOutlayPersistence outlayPersistence)
    {
        _outlayPersistence = outlayPersistence;
    }

    public async Task<OutlayDashVm[]> Handle(OutlayTargetQuery request, CancellationToken cancellationToken) =>
        await _outlayPersistence.GetOutlayTargetAsync(request.Tenant, request.Region);
}