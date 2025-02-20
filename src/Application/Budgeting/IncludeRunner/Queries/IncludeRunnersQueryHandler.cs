using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.IncludeRunner.Queries;

public class IncludeRunnersQueryHandler : RequestHandlerBase, IRequestHandler<IncludeRunnersQuery, IncludeRunnerVm[]>
{
    private readonly IIncludeRunnerService _includeRunnerService;

    public IncludeRunnersQueryHandler(IIncludeRunnerService includeRunnerService)
    {
        _includeRunnerService = includeRunnerService;
    }

    public async Task<IncludeRunnerVm[]> Handle(IncludeRunnersQuery request, CancellationToken cancellationToken) => 
        await _includeRunnerService.GetAllAsync(true);
}
