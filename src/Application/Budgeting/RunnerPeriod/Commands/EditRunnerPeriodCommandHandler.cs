using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriod.Commands;

public class EditRunnerPeriodCommandHandler : IRequestHandler<EditRunnerPeriodCommand, RunnerPeriodCommandResponse>
{
    private readonly IRunnerPeriodPersistence _runnerPeriodPersistence;
    private readonly IMapper _mapper;

    public EditRunnerPeriodCommandHandler(IRunnerPeriodPersistence runnerPeriodPersistence, IMapper mapper)
    {
        _runnerPeriodPersistence = runnerPeriodPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerPeriodCommandResponse> Handle(EditRunnerPeriodCommand request, CancellationToken cancellationToken)
    {
        var response = new RunnerPeriodCommandResponse();
        var runnerPeriod = _mapper.Map<Domain.Entity.Budgeting.RunnerPeriod>(request.RunnerPeriod);

        var result = await _runnerPeriodPersistence.EditAsync(runnerPeriod);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<RunnerPeriodVm>(result.Entity);

        return response;
    }
}