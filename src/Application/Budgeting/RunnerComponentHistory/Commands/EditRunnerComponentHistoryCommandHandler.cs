using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponentHistory.Commands;

public class EditRunnerComponentHistoryCommandHandler : IRequestHandler<EditRunnerComponentHistoryCommand, RunnerComponentHistoryCommandResponse>
{
    private readonly IRunnerComponentHistoryPersistence _runnerComponentHistoryPersistence;
    private readonly IMapper _mapper;

    public EditRunnerComponentHistoryCommandHandler(IRunnerComponentHistoryPersistence runnerComponentHistoryPersistence, IMapper mapper)
    {
        _runnerComponentHistoryPersistence = runnerComponentHistoryPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerComponentHistoryCommandResponse> Handle(EditRunnerComponentHistoryCommand request, CancellationToken cancellationToken)
    {
        var response = new RunnerComponentHistoryCommandResponse();
        var runnerComponentHistory = _mapper.Map<Domain.Entity.Budgeting.RunnerComponentHistory>(request.RunnerComponentHistory);

        var result = await _runnerComponentHistoryPersistence.EditAsync(runnerComponentHistory);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<RunnerComponentHistoryVm>(result.Entity);

        return response;
    }
}