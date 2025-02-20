using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriod.Commands;

public class CreateRunnerPeriodCommandHandler : IRequestHandler<CreateRunnerPeriodCommand, RunnerPeriodCommandResponse>
{
    private readonly IRunnerPeriodPersistence _runnerPeriodPersistence;
    private readonly IMapper _mapper;

    public CreateRunnerPeriodCommandHandler(IRunnerPeriodPersistence runnerPeriodPersistence, IMapper mapper)
    {
        _runnerPeriodPersistence = runnerPeriodPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerPeriodCommandResponse> Handle(CreateRunnerPeriodCommand request, CancellationToken cancellationToken)
    {
        request.RunnerPeriod = UpdateRunnerPeriod(request.RunnerPeriod);

        var response = new RunnerPeriodCommandResponse();
        var runnerPeriod = _mapper.Map<Domain.Entity.Budgeting.RunnerPeriod>(request.RunnerPeriod);

        var result = await _runnerPeriodPersistence.AddAsync(runnerPeriod);

        if (result.Status != RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null;
            return response;
        }

        response.Data = _mapper.Map<RunnerPeriodVm>(result.Entity);
        return response;
    }

    private static RunnerPeriodVm UpdateRunnerPeriod(RunnerPeriodVm runnerPeriod)
    {
        runnerPeriod.Code = "000000";
        runnerPeriod.Status = "60";
        runnerPeriod.Month = runnerPeriod.StartDate.Month.ToString().ToTwoChar();
        runnerPeriod.Week = runnerPeriod.StartDate.ToWeekOfYear().ToString().ToTwoChar();
        runnerPeriod.ComponentWeek = runnerPeriod.Week;
        runnerPeriod.YearWeek = runnerPeriod.Week;

        return runnerPeriod;
    }
}