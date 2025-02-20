using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.DateGeneration.Queries;

public class DateGenerationQueryHandler : RequestHandlerBase, IRequestHandler<DateGenerationQuery, DateGenerationVm>
{
    private readonly IDateGenerationService _dateGenerationService;

    public DateGenerationQueryHandler(IDateGenerationService dateGenerationService)
    {
        _dateGenerationService = dateGenerationService;
    }

    public async Task<DateGenerationVm> Handle(DateGenerationQuery request, CancellationToken cancellationToken) =>
        await _dateGenerationService.GetAsync(request.Tenant, request.Code);
}