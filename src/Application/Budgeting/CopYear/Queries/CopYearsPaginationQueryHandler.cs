using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYear.Queries;

public class CopYearsPaginationQueryHandler : RequestHandlerBase, IRequestHandler<CopYearsPaginationQuery, CopYearVm[]>
{
    private readonly ICopYearService _copYearService;

    public CopYearsPaginationQueryHandler(ICopYearService copYearService)
    {
        _copYearService = copYearService;
    }

    public async Task<CopYearVm[]> Handle(CopYearsPaginationQuery request, CancellationToken cancellationToken) =>
        await _copYearService.GetAllAsync(true, request.Page, request.Count);
}
