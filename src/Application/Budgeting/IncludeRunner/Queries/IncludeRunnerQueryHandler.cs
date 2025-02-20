using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.IncludeRunner.Queries;

public class IncludeRunnerQueryHandler : RequestHandlerBase, IRequestHandler<IncludeRunnerQuery, IncludeRunnerVm>
{
    private readonly IIncludeRunnerService _includeRunnerService;

    public IncludeRunnerQueryHandler(IIncludeRunnerService includeRunnerService)
    {
        _includeRunnerService = includeRunnerService;
    }

    public async Task<IncludeRunnerVm> Handle(IncludeRunnerQuery request, CancellationToken cancellationToken) =>
        await _includeRunnerService.GetAsync(request.Runner, request.User);
}