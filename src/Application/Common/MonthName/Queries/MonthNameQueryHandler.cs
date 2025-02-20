using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.MonthName.Queries;

public class MonthNameQueryHandler : RequestHandlerBase, IRequestHandler<MonthNameQuery, MonthNameVm>
{
    private readonly IMonthNameService _monthNameService;

    public MonthNameQueryHandler(IMonthNameService monthNameService)
    {
        _monthNameService = monthNameService;
    }

    public async Task<MonthNameVm> Handle(MonthNameQuery request, CancellationToken cancellationToken) =>
        await _monthNameService.GetAsync(request.Tenant, request.Code);
}