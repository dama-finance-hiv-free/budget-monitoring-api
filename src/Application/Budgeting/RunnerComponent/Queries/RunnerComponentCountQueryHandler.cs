using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponent.Queries;

public class RunnerComponentCountQueryHandler : RequestHandlerBase, IRequestHandler<RunnerComponentCountQuery, int>
{
    private readonly IRunnerComponentService _runnerComponentService;

    public RunnerComponentCountQueryHandler(IRunnerComponentService runnerComponentService)
    {
        _runnerComponentService = runnerComponentService;
    }

    public async Task<int> Handle(RunnerComponentCountQuery request, CancellationToken cancellationToken) =>
        await _runnerComponentService.GetCount(true);
}