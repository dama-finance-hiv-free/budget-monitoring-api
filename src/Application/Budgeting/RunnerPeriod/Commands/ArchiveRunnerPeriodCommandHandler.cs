using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriod.Commands;

public class ArchiveRunnerPeriodCommandHandler : 
    IRequestHandler<ArchiveRunnerPeriodCommand, RunnerPeriodCommandResponse>
{
    private readonly IRunnerPeriodPersistence _runnerPeriodPersistence;
    private readonly IMapper _mapper;

    public ArchiveRunnerPeriodCommandHandler(IRunnerPeriodPersistence runnerPeriodPersistence, IMapper mapper)
    {
        _runnerPeriodPersistence = runnerPeriodPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerPeriodCommandResponse> Handle(ArchiveRunnerPeriodCommand request,
        CancellationToken cancellationToken)
    {
        var response = new RunnerPeriodCommandResponse();

        var runnerPeriod = _mapper.Map<Domain.Entity.Budgeting.RunnerPeriod>(request.RunnerPeriod);

        var result = await _runnerPeriodPersistence.ArchiveAsync(runnerPeriod);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;
        }

        response.Data = _mapper.Map<RunnerPeriodVm>(result.Entity);

        return response;
    }
}