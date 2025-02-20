using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Quarter.Queries;

public class QuartersQueryHandler : RequestHandlerBase, IRequestHandler<QuartersQuery, QuarterVm[]>
{
    private readonly IQuarterService _quarterService;

    public QuartersQueryHandler(IQuarterService quarterService)
    {
        _quarterService = quarterService;
    }

    public async Task<QuarterVm[]> Handle(QuartersQuery request, CancellationToken cancellationToken) => 
        await _quarterService.GetAllAsync(true);

}
