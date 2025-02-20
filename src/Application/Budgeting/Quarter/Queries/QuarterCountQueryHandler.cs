using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Quarter.Queries;

public class QuarterCountQueryHandler : RequestHandlerBase, IRequestHandler<QuarterCountQuery, int>
{
    private readonly IQuarterService _quarterService;

    public QuarterCountQueryHandler(IQuarterService quarterService)
    {
        _quarterService = quarterService;
    }

    public async Task<int> Handle(QuarterCountQuery request, CancellationToken cancellationToken) =>
        await _quarterService.GetCount(true);
}