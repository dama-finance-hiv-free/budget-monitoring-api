using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYear.Queries;

public class CopYearCountQueryHandler : RequestHandlerBase, IRequestHandler<CopYearCountQuery, int>
{
    private readonly ICopYearService _copYearService;

    public CopYearCountQueryHandler(ICopYearService copYearService)
    {
        _copYearService = copYearService;
    }

    public async Task<int> Handle(CopYearCountQuery request, CancellationToken cancellationToken) =>
        await _copYearService.GetCount(true);
}