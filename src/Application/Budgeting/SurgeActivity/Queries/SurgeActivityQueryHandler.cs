using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SurgeActivity.Queries;

public class SurgeActivityQueryHandler : RequestHandlerBase, IRequestHandler<SurgeActivityQuery, SurgeActivityVm>
{
    private readonly ISurgeActivityService _surgeActivityService;

    public SurgeActivityQueryHandler(ISurgeActivityService surgeActivityService)
    {
        _surgeActivityService = surgeActivityService;
    }

    public async Task<SurgeActivityVm> Handle(SurgeActivityQuery request, CancellationToken cancellationToken) =>
        await _surgeActivityService.GetAsync(request.Code, request.Code);
}