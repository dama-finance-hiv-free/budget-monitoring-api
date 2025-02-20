using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Town.Queries;

public class TownQueryHandler : RequestHandlerBase, IRequestHandler<TownQuery, TownVm>
{
    private readonly ITownService _townService;

    public TownQueryHandler(ITownService townService)
    {
        _townService = townService;
    }

    public async Task<TownVm> Handle(TownQuery request, CancellationToken cancellationToken) =>
        await _townService.GetAsync(request.Code, request.Code);
}