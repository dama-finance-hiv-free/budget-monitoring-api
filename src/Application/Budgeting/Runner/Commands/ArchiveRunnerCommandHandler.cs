using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Runner.Commands;

public class ArchiveRunnerCommandHandler : IRequestHandler<ArchiveRunnerCommand, RunnerCommandResponse>
{
    private readonly IRunnerPersistence _runnerPersistence;
    private readonly IMapper _mapper;

    public ArchiveRunnerCommandHandler(IRunnerPersistence runnerPersistence, IMapper mapper)
    {
        _runnerPersistence = runnerPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerCommandResponse> Handle(ArchiveRunnerCommand request, CancellationToken cancellationToken)
    {
        var response = new RunnerCommandResponse();
        var runner = _mapper.Map<Domain.Entity.Budgeting.Runner>(request.Runner);

        var result = await _runnerPersistence.ArchiveAsync(runner);

        if (result.Status != RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<RunnerVm>(result.Entity);

        return response;
    }
}