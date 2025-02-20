using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Strategy.Commands;

public class EditStrategyCommandHandler : IRequestHandler<EditStrategyCommand, StrategyCommandResponse>
{
    private readonly IStrategyPersistence _strategyPersistence;
    private readonly IMapper _mapper;

    public EditStrategyCommandHandler(IStrategyPersistence strategyPersistence, IMapper mapper)
    {
        _strategyPersistence = strategyPersistence;
        _mapper = mapper;
    }

    public async Task<StrategyCommandResponse> Handle(EditStrategyCommand request, CancellationToken cancellationToken)
    {
        var response = new StrategyCommandResponse();
        var strategy = _mapper.Map<Domain.Entity.Budgeting.Strategy>(request.Strategy);

        var result = await _strategyPersistence.EditAsync(strategy);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<StrategyVm>(result.Entity);

        return response;
    }
}