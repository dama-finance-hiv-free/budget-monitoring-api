using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Strategy.Queries;

public class StrategiesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<StrategiesPaginationQuery, StrategyVm[]>
{
    private readonly IStrategyService _strategyService;

    public StrategiesPaginationQueryHandler(IStrategyService strategyService)
    {
        _strategyService = strategyService;
    }

    public async Task<StrategyVm[]> Handle(StrategiesPaginationQuery request, CancellationToken cancellationToken) =>
        await _strategyService.GetAllAsync(true, request.Page, request.Count);
}
