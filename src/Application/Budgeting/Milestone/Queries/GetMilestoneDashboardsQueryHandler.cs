using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Milestone.Queries;

public class GetMilestoneDashboardsQueryHandler : RequestHandlerBase, IRequestHandler<GetMilestoneDashboardsQuery, MilestoneDashboardVm[]>
{
    private readonly IMilestonePersistence _milestonePersistence;
    private readonly IMapper _mapper;

    public GetMilestoneDashboardsQueryHandler(IMilestonePersistence milestonePersistence, IMapper mapper)
    {
        _milestonePersistence = milestonePersistence;
        _mapper = mapper;
    }
    public async Task<MilestoneDashboardVm[]> Handle(GetMilestoneDashboardsQuery request, CancellationToken cancellationToken)
    {
        var milestoneDashboards = await _milestonePersistence.GetMilestoneDashboardBySite(request.Options);
        return _mapper.Map<MilestoneDashboardVm[]>(milestoneDashboards);
    }
}