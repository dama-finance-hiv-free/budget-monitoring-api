using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.MonthName.Queries;

public class MonthNamesQueryHandler : RequestHandlerBase, IRequestHandler<MonthNamesQuery, MonthNameVm[]>
{
    private readonly IMonthNameService _monthNameService;

    public MonthNamesQueryHandler(IMonthNameService monthNameService)
    {
        _monthNameService = monthNameService;
    }

    public async Task<MonthNameVm[]> Handle(MonthNamesQuery request, CancellationToken cancellationToken) =>
        await _monthNameService.GetMonthNamesAsync(request.Lid);
}