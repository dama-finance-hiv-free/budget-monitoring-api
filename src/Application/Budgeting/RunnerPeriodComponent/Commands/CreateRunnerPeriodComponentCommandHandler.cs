using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodComponent.Commands;

public class CreateRunnerPeriodComponentCommandHandler : IRequestHandler<CreateRunnerPeriodComponentCommand, RunnerPeriodComponentCommandResponse>
{
    private readonly IRunnerPeriodComponentPersistence _runnerPeriodComponentPersistence;
    private readonly IMapper _mapper;

    public CreateRunnerPeriodComponentCommandHandler(IRunnerPeriodComponentPersistence runnerPeriodComponentPersistence, IMapper mapper)
    {
        _runnerPeriodComponentPersistence = runnerPeriodComponentPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerPeriodComponentCommandResponse> Handle(CreateRunnerPeriodComponentCommand request, CancellationToken cancellationToken)
    {
        var response = new RunnerPeriodComponentCommandResponse();
        var runnerPeriodComponent = _mapper.Map<Domain.Entity.Budgeting.RunnerPeriodComponent>(request.RunnerPeriodComponent);

        var result = await _runnerPeriodComponentPersistence.AddAsync(runnerPeriodComponent);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<RunnerPeriodComponentVm>(result.Entity);

        return response;
    }
}