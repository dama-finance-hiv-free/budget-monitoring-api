using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerStatus.Commands;

public class CreateRunnerStatusCommandHandler : IRequestHandler<CreateRunnerStatusCommand, RunnerStatusCommandResponse>
{
    private readonly IRunnerStatusPersistence _runnerStatusPersistence;
    private readonly IMapper _mapper;

    public CreateRunnerStatusCommandHandler(IRunnerStatusPersistence runnerStatusPersistence, IMapper mapper)
    {
        _runnerStatusPersistence = runnerStatusPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerStatusCommandResponse> Handle(CreateRunnerStatusCommand request, CancellationToken cancellationToken)
    {
        var response = new RunnerStatusCommandResponse();
        var runnerStatus = _mapper.Map<Domain.Entity.Budgeting.RunnerStatus>(request.RunnerStatus);

        var result = await _runnerStatusPersistence.AddAsync(runnerStatus);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<RunnerStatusVm>(result.Entity);

        return response;
    }
}