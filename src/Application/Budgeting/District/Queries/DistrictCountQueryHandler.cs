using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.District.Queries;

public class DistrictCountQueryHandler : RequestHandlerBase, IRequestHandler<DistrictCountQuery, int>
{
    private readonly IDistrictService _districtService;

    public DistrictCountQueryHandler(IDistrictService districtService)
    {
        _districtService = districtService;
    }

    public async Task<int> Handle(DistrictCountQuery request, CancellationToken cancellationToken) =>
        await _districtService.GetCount(true);
}