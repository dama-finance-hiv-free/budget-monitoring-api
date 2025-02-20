using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.District.Queries;

public class DistrictsPaginationQueryHandler : RequestHandlerBase, IRequestHandler<DistrictsPaginationQuery, DistrictVm[]>
{
    private readonly IDistrictService _districtService;

    public DistrictsPaginationQueryHandler(IDistrictService districtService)
    {
        _districtService = districtService;
    }

    public async Task<DistrictVm[]> Handle(DistrictsPaginationQuery request, CancellationToken cancellationToken) =>
        await _districtService.GetAllAsync(true, request.Page, request.Count);
}
