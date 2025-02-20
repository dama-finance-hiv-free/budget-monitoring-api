using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.AnnualTarget.Queries;

public class AnnualTargetQueryHandler : RequestHandlerBase, IRequestHandler<AnnualTargetQuery, AnnualTargetVm>
{
    private readonly IAnnualTargetService _annualTargetService;

    public AnnualTargetQueryHandler(IAnnualTargetService annualTargetService)
    {
        _annualTargetService = annualTargetService;
    }

    public async Task<AnnualTargetVm> Handle(AnnualTargetQuery request, CancellationToken cancellationToken) =>
        await _annualTargetService.GetAsync(request.Tenant, request.CopYear);
}