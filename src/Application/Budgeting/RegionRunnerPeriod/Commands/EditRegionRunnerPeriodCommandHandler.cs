using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RegionRunnerPeriod.Commands;

public class EditRegionRunnerPeriodCommandHandler :  IRequestHandler<EditRegionRunnerPeriodCommand, RegionRunnerPeriodCommandResponse>
{
    private readonly IRegionRunnerPeriodPersistence _regionRunnerPeriodPersistence;
    private readonly IMapper _mapper;

    public EditRegionRunnerPeriodCommandHandler(IRegionRunnerPeriodPersistence regionRunnerPeriodPersistence, IMapper mapper)
    {
        _regionRunnerPeriodPersistence = regionRunnerPeriodPersistence;
        _mapper = mapper;
    }

    public async Task<RegionRunnerPeriodCommandResponse> Handle(EditRegionRunnerPeriodCommand request, CancellationToken cancellationToken)
    {
        var response = new RegionRunnerPeriodCommandResponse();
        var regionRunnerPeriod = _mapper.Map<Domain.Entity.Budgeting.RegionRunnerPeriod>(request.RegionRunnerPeriod);


        var result = await _regionRunnerPeriodPersistence.EditAsync(regionRunnerPeriod);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<RegionRunnerPeriodVm>(result.Entity);

        return response;
    }
}