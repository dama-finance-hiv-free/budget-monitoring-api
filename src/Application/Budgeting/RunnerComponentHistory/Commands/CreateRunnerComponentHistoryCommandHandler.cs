using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponentHistory.Commands;

public class CreateRunnerComponentHistoryCommandHandler : IRequestHandler<CreateRunnerComponentHistoryCommand, RunnerComponentHistoryCommandResponse>
{
    private readonly IRunnerComponentHistoryPersistence _runnerComponentHistoryPersistence;
    private readonly IMapper _mapper;

    public CreateRunnerComponentHistoryCommandHandler(IRunnerComponentHistoryPersistence runnerComponentHistoryPersistence, IMapper mapper)
    {
        _runnerComponentHistoryPersistence = runnerComponentHistoryPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerComponentHistoryCommandResponse> Handle(CreateRunnerComponentHistoryCommand request, CancellationToken cancellationToken)
    {
        var response = new RunnerComponentHistoryCommandResponse();
        var runnerComponentHistory = _mapper.Map<Domain.Entity.Budgeting.RunnerComponentHistory>(request.RunnerComponentHistory);

        var result = await _runnerComponentHistoryPersistence.AddAsync(runnerComponentHistory);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<RunnerComponentHistoryVm>(result.Entity);

        return response;
    }
}