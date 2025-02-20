using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerStatus.Commands;

public class EditRunnerStatusCommandHandler : IRequestHandler<EditRunnerStatusCommand, RunnerStatusCommandResponse>
{
    private readonly IRunnerStatusPersistence _runnerStatusPersistence;
    private readonly IMapper _mapper;

    public EditRunnerStatusCommandHandler(IRunnerStatusPersistence runnerStatusPersistence, IMapper mapper)
    {
        _runnerStatusPersistence = runnerStatusPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerStatusCommandResponse> Handle(EditRunnerStatusCommand request, CancellationToken cancellationToken)
    {
        var response = new RunnerStatusCommandResponse();
        var runnerStatus = _mapper.Map<Domain.Entity.Budgeting.RunnerStatus>(request.RunnerStatus);

        var result = await _runnerStatusPersistence.EditAsync(runnerStatus);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<RunnerStatusVm>(result.Entity);

        return response;
    }
}