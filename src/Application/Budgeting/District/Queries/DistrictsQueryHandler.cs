using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.District.Queries;

public class DistrictsQueryHandler : RequestHandlerBase, IRequestHandler<DistrictsQuery, DistrictVm[]>
{
    private readonly IDistrictService _districtService;

    public DistrictsQueryHandler(IDistrictService districtService)
    {
        _districtService = districtService;
    }

    public async Task<DistrictVm[]> Handle(DistrictsQuery request, CancellationToken cancellationToken) => 
        await _districtService.GetAllAsync(true);
}
