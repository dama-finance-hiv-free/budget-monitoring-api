using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.IncludeRunner.Queries;

public class IncludeRunnerCountQueryHandler : RequestHandlerBase, IRequestHandler<IncludeRunnerCountQuery, int>
{
    private readonly IIncludeRunnerService _includeRunnerService;

    public IncludeRunnerCountQueryHandler(IIncludeRunnerService includeRunnerService)
    {
        _includeRunnerService = includeRunnerService;
    }

    public async Task<int> Handle(IncludeRunnerCountQuery request, CancellationToken cancellationToken) =>
        await _includeRunnerService.GetCount(true);
}