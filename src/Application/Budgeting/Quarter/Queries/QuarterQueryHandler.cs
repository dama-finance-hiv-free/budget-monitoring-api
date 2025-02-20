using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Quarter.Queries;

public class QuarterQueryHandler : RequestHandlerBase, IRequestHandler<QuarterQuery, QuarterVm>
{
    private readonly IQuarterService _quarterService;

    public QuarterQueryHandler(IQuarterService quarterService)
    {
        _quarterService = quarterService;
    }

    public async Task<QuarterVm> Handle(QuarterQuery request, CancellationToken cancellationToken) =>
        await _quarterService.GetAsync(request.Tenant, request.Code);
}