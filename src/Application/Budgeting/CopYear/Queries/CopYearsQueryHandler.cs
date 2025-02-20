using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYear.Queries;

public class CopYearsQueryHandler : RequestHandlerBase, IRequestHandler<CopYearsQuery, CopYearVm[]>
{
    private readonly ICopYearService _copYearService;

    public CopYearsQueryHandler(ICopYearService copYearService)
    {
        _copYearService = copYearService;
    }

    public async Task<CopYearVm[]> Handle(CopYearsQuery request, CancellationToken cancellationToken) => 
        await _copYearService.GetAllAsync(true);
}
