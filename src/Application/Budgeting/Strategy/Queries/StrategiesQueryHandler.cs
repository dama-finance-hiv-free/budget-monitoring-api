using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Strategy.Queries;

public class StrategiesQueryHandler : RequestHandlerBase, IRequestHandler<StrategiesQuery, StrategyVm[]>
{
    private readonly IStrategyService _strategyService;

    public StrategiesQueryHandler(IStrategyService strategyService)
    {
        _strategyService = strategyService;
    }

    public async Task<StrategyVm[]> Handle(StrategiesQuery request, CancellationToken cancellationToken) => 
        await _strategyService.GetAllAsync(true);
}
