using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponent.Commands;

public class CreateRunnerComponentCommandHandler : IRequestHandler<CreateRunnerComponentCommand, RunnerComponentCommandResponse>
{
    private readonly IRunnerComponentPersistence _runnerComponentPersistence;
    private readonly IMapper _mapper;

    public CreateRunnerComponentCommandHandler(IRunnerComponentPersistence runnerComponentPersistence, IMapper mapper)
    {
        _runnerComponentPersistence = runnerComponentPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerComponentCommandResponse> Handle(CreateRunnerComponentCommand request, CancellationToken cancellationToken)
    {
        var response = new RunnerComponentCommandResponse();
        var runnerComponent = _mapper.Map<Domain.Entity.Budgeting.RunnerComponent>(request.RunnerComponent);

        var result = await _runnerComponentPersistence.AddAsync(runnerComponent);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<RunnerComponentVm>(result.Entity);

        return response;
    }
}