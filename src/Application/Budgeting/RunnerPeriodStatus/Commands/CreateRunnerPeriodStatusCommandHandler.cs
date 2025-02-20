using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodStatus.Commands;

public class CreateRunnerPeriodStatusCommandHandler : IRequestHandler<CreateRunnerPeriodStatusCommand, RunnerPeriodStatusCommandResponse>
{
    private readonly IRunnerPeriodStatusPersistence _runnerPeriodStatusPersistence;
    private readonly IMapper _mapper;

    public CreateRunnerPeriodStatusCommandHandler(IRunnerPeriodStatusPersistence runnerPeriodStatusPersistence, IMapper mapper)
    {
        _runnerPeriodStatusPersistence = runnerPeriodStatusPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerPeriodStatusCommandResponse> Handle(CreateRunnerPeriodStatusCommand request, CancellationToken cancellationToken)
    {
        var response = new RunnerPeriodStatusCommandResponse();
        var runnerPeriodStatus = _mapper.Map<Domain.Entity.Budgeting.RunnerPeriodStatus>(request.RunnerPeriodStatus);

        var result = await _runnerPeriodStatusPersistence.AddAsync(runnerPeriodStatus);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<RunnerPeriodStatusVm>(result.Entity);

        return response;
    }
}