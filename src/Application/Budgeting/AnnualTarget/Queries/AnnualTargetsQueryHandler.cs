using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.AnnualTarget.Queries;

public class AnnualTargetsQueryHandler : RequestHandlerBase, IRequestHandler<AnnualTargetsQuery, AnnualTargetVm[]>
{
    private readonly IAnnualTargetService _annualTargetService;

    public AnnualTargetsQueryHandler(IAnnualTargetService annualTargetService)
    {
        _annualTargetService = annualTargetService;
    }

    public async Task<AnnualTargetVm[]> Handle(AnnualTargetsQuery request, CancellationToken cancellationToken) => 
        await _annualTargetService.GetAllAsync(true);
}
