using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Target.Commands;

public class CreateTargetCommandHandler : IRequestHandler<CreateTargetCommand, TargetCommandResponse>
{
    private readonly ITargetPersistence _targetPersistence;
    private readonly IMapper _mapper;

    public CreateTargetCommandHandler(ITargetPersistence targetPersistence, IMapper mapper)
    {
        _targetPersistence = targetPersistence;
        _mapper = mapper;
    }

    public async Task<TargetCommandResponse> Handle(CreateTargetCommand request, CancellationToken cancellationToken)
    {
        var response = new TargetCommandResponse();
        var target = _mapper.Map<Domain.Entity.Budgeting.Target>(request.Target);

        var result = await _targetPersistence.AddAsync(target);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<TargetVm>(result.Entity);

        return response;
    }
}