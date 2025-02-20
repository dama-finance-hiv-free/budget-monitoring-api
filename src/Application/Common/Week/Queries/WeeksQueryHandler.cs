using System.Threading;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Common.Week.Queries;

public class WeeksQueryHandler : RequestHandlerBase, IRequestHandler<WeeksQuery, WeekVm[]>
{
    private readonly IWeekService _weekService;
    private readonly ICopYearService _copYearService;

    public WeeksQueryHandler(IWeekService weekService, ICopYearService copYearService)
    {
        _weekService = weekService;
        _copYearService = copYearService;
    }

    public async Task<WeekVm[]> Handle(WeeksQuery request, CancellationToken cancellationToken)
    {
        var copYear = await _copYearService.GetCopYearAsync(request.Tenant, request.Params.CopYear);

        var weeks = await _weekService.GetWeeksAsync(copYear.StartDate.ToUtcDate(), copYear.EndDate.ToUtcDate(),
            copYear.Code);
        return weeks;
    }
}