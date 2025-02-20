using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Component.Commands;

public class CreateComponentCommandHandler : IRequestHandler<CreateComponentCommand, ComponentCommandResponse>
{
    private readonly IComponentPersistence _componentPersistence;
    private readonly IMapper _mapper;

    public CreateComponentCommandHandler(IComponentPersistence componentPersistence, IMapper mapper)
    {
        _componentPersistence = componentPersistence;
        _mapper = mapper;
    }

    public async Task<ComponentCommandResponse> Handle(CreateComponentCommand request, CancellationToken cancellationToken)
    {
        var response = new ComponentCommandResponse();
        var component = _mapper.Map<Domain.Entity.Budgeting.Component>(request.Component);

        var result = await _componentPersistence.AddAsync(component);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<ComponentVm>(result.Entity);

        return response;
    }
}