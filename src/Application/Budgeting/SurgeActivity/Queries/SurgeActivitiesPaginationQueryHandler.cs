using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SurgeActivity.Queries;

public class SurgeActivitiesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<SurgeActivitiesPaginationQuery, SurgeActivityVm[]>
{
    private readonly ISurgeActivityService _surgeActivityService;

    public SurgeActivitiesPaginationQueryHandler(ISurgeActivityService surgeActivityService)
    {
        _surgeActivityService = surgeActivityService;
    }

    public async Task<SurgeActivityVm[]> Handle(SurgeActivitiesPaginationQuery request, CancellationToken cancellationToken) =>
        await _surgeActivityService.GetAllAsync(true, request.Page, request.Count);
}
