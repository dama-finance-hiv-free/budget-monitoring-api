using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SurgeActivity.Queries;

public class SurgeActivityCountQueryHandler : RequestHandlerBase, IRequestHandler<SurgeActivityCountQuery, int>
{
    private readonly ISurgeActivityService _surgeActivityService;

    public SurgeActivityCountQueryHandler(ISurgeActivityService surgeActivityService)
    {
        _surgeActivityService = surgeActivityService;
    }

    public async Task<int> Handle(SurgeActivityCountQuery request, CancellationToken cancellationToken) =>
        await _surgeActivityService.GetCount(true);
}