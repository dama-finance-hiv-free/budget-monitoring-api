using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.DateGeneration.Queries;

public class DateGenerationsQueryHandler : RequestHandlerBase, IRequestHandler<DateGenerationsQuery, DateGenerationVm[]>
{
    private readonly IDateGenerationService _dateGenerationService;

    public DateGenerationsQueryHandler(IDateGenerationService dateGenerationService)
    {
        _dateGenerationService = dateGenerationService;
    }

    public async Task<DateGenerationVm[]> Handle(DateGenerationsQuery request, CancellationToken cancellationToken) => 
        await _dateGenerationService.GetAllAsync(true);
}