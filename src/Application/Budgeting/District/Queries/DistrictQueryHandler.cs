using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.District.Queries;

public class DistrictQueryHandler : RequestHandlerBase, IRequestHandler<DistrictQuery, DistrictVm>
{
    private readonly IDistrictService _districtService;

    public DistrictQueryHandler(IDistrictService districtService)
    {
        _districtService = districtService;
    }

    public async Task<DistrictVm> Handle(DistrictQuery request, CancellationToken cancellationToken) =>
        await _districtService.GetAsync(request.Tenant, request.Code);
}