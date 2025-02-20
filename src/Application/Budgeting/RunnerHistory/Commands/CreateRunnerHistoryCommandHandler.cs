using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerHistory.Commands;

public class CreateRunnerHistoryCommandHandler : IRequestHandler<CreateRunnerHistoryCommand, RunnerHistoryCommandResponse>
{
    private readonly IRunnerHistoryPersistence _runnerHistoryPersistence;
    private readonly IMapper _mapper;

    public CreateRunnerHistoryCommandHandler(IRunnerHistoryPersistence runnerHistoryPersistence, IMapper mapper)
    {
        _runnerHistoryPersistence = runnerHistoryPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerHistoryCommandResponse> Handle(CreateRunnerHistoryCommand request, CancellationToken cancellationToken)
    {
        var response = new RunnerHistoryCommandResponse();
        var runnerHistory = _mapper.Map<Domain.Entity.Budgeting.RunnerHistory>(request.RunnerHistory);

        var result = await _runnerHistoryPersistence.AddAsync(runnerHistory);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<RunnerHistoryVm>(result.Entity);

        return response;
    }
}