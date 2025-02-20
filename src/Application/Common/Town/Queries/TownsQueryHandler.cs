using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Town.Queries;

public class TownsQueryHandler : RequestHandlerBase, IRequestHandler<TownsQuery, TownVm[]>
{
    private readonly ITownService _townService;

    public TownsQueryHandler(ITownService townService)
    {
        _townService = townService;
    }

    public async Task<TownVm[]> Handle(TownsQuery request, CancellationToken cancellationToken) =>
        await _townService.GetAllAsync(true);
}