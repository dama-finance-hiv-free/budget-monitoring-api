using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.District.Commands;

public class EditDistrictCommandHandler : IRequestHandler<EditDistrictCommand, DistrictCommandResponse>
{
    private readonly IDistrictPersistence _districtPersistence;
    private readonly IMapper _mapper;

    public EditDistrictCommandHandler(IDistrictPersistence districtPersistence, IMapper mapper)
    {
        _districtPersistence = districtPersistence;
        _mapper = mapper;
    }

    public async Task<DistrictCommandResponse> Handle(EditDistrictCommand request, CancellationToken cancellationToken)
    {
        var response = new DistrictCommandResponse();
        var district = _mapper.Map<Domain.Entity.Budgeting.District>(request.District);

        var result = await _districtPersistence.EditAsync(district);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<DistrictVm>(result.Entity);

        return response;
    }
}