using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Strategy.Queries;

public class StrategyCountQueryHandler : RequestHandlerBase, IRequestHandler<StrategyCountQuery, int>
{
    private readonly IStrategyService _strategyService;

    public StrategyCountQueryHandler(IStrategyService strategyService)
    {
        _strategyService = strategyService;
    }

    public async Task<int> Handle(StrategyCountQuery request, CancellationToken cancellationToken) =>
        await _strategyService.GetCount(true);
}