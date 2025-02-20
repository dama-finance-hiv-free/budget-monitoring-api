using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Runner.Queries;

public class RunnerCountQueryHandler : RequestHandlerBase, IRequestHandler<RunnerCountQuery, int>
{
    private readonly IRunnerService _runnerService;

    public RunnerCountQueryHandler(IRunnerService runnerService)
    {
        _runnerService = runnerService;
    }

    public async Task<int> Handle(RunnerCountQuery request, CancellationToken cancellationToken) =>
        await _runnerService.GetCount(true);
}