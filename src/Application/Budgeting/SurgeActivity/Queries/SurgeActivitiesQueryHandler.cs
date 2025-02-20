using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SurgeActivity.Queries;

public class SurgeActivitiesQueryHandler : RequestHandlerBase, IRequestHandler<SurgeActivitiesQuery, SurgeActivityVm[]>
{
    private readonly ISurgeActivityService _surgeActivityService;

    public SurgeActivitiesQueryHandler(ISurgeActivityService surgeActivityService)
    {
        _surgeActivityService = surgeActivityService;
    }

    public async Task<SurgeActivityVm[]> Handle(SurgeActivitiesQuery request, CancellationToken cancellationToken) => 
        await _surgeActivityService.GetAllAsync(true);
}
