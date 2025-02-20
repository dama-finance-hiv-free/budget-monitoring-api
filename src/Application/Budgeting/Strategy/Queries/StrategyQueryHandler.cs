using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Strategy.Queries;

public class StrategyQueryHandler : RequestHandlerBase, IRequestHandler<StrategyQuery, StrategyVm>
{
    private readonly IStrategyService _strategyService;

    public StrategyQueryHandler(IStrategyService strategyService)
    {
        _strategyService = strategyService;
    }

    public async Task<StrategyVm> Handle(StrategyQuery request, CancellationToken cancellationToken) =>
        await _strategyService.GetAsync(request.Tenant, request.Code);
}