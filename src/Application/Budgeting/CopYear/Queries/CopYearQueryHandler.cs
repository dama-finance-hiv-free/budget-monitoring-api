using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYear.Queries;

public class CopYearQueryHandler : RequestHandlerBase, IRequestHandler<CopYearQuery, CopYearVm>
{
    private readonly ICopYearService _copYearService;

    public CopYearQueryHandler(ICopYearService copYearService)
    {
        _copYearService = copYearService;
    }

    public async Task<CopYearVm> Handle(CopYearQuery request, CancellationToken cancellationToken) =>
        await _copYearService.GetAsync(request.Tenant, request.Code);
}