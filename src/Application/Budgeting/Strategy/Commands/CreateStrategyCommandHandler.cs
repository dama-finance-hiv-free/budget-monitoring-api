using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Strategy.Commands;

public class CreateStrategyCommandHandler : IRequestHandler<CreateStrategyCommand, StrategyCommandResponse>
{
    private readonly IStrategyPersistence _strategyPersistence;
    private readonly IMapper _mapper;

    public CreateStrategyCommandHandler(IStrategyPersistence strategyPersistence, IMapper mapper)
    {
        _strategyPersistence = strategyPersistence;
        _mapper = mapper;
    }

    public async Task<StrategyCommandResponse> Handle(CreateStrategyCommand request, CancellationToken cancellationToken)
    {
        var response = new StrategyCommandResponse();
        var strategy = _mapper.Map<Domain.Entity.Budgeting.Strategy>(request.Strategy);

        var result = await _strategyPersistence.AddAsync(strategy);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<StrategyVm>(result.Entity);

        return response;
    }
}