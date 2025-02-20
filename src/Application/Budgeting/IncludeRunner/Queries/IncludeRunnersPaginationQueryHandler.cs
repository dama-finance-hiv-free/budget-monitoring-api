using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.IncludeRunner.Queries;

public class IncludeRunnersPaginationQueryHandler : RequestHandlerBase, IRequestHandler<IncludeRunnersPaginationQuery, IncludeRunnerVm[]>
{
    private readonly IIncludeRunnerService _includeRunnerService;

    public IncludeRunnersPaginationQueryHandler(IIncludeRunnerService includeRunnerService)
    {
        _includeRunnerService = includeRunnerService;
    }

    public async Task<IncludeRunnerVm[]> Handle(IncludeRunnersPaginationQuery request, CancellationToken cancellationToken) =>
        await _includeRunnerService.GetAllAsync(true, request.Page, request.Count);
}
