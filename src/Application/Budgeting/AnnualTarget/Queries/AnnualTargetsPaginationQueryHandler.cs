using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.AnnualTarget.Queries;

public class AnnualTargetsPaginationQueryHandler : RequestHandlerBase, IRequestHandler<AnnualTargetsPaginationQuery, AnnualTargetVm[]>
{
    private readonly IAnnualTargetService _annualTargetService;

    public AnnualTargetsPaginationQueryHandler(IAnnualTargetService annualTargetService)
    {
        _annualTargetService = annualTargetService;
    }

    public async Task<AnnualTargetVm[]> Handle(AnnualTargetsPaginationQuery request, CancellationToken cancellationToken) =>
        await _annualTargetService.GetAllAsync(true, request.Page, request.Count);
}
