using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Quarter.Queries;

public class QuartersPaginationQueryHandler : RequestHandlerBase, IRequestHandler<QuartersPaginationQuery, QuarterVm[]>
{
    private readonly IQuarterService _quarterService;

    public QuartersPaginationQueryHandler(IQuarterService quarterService)
    {
        _quarterService = quarterService;
    }

    public async Task<QuarterVm[]> Handle(QuartersPaginationQuery request, CancellationToken cancellationToken) =>
        await _quarterService.GetAllAsync(true, request.Page, request.Count);
}
