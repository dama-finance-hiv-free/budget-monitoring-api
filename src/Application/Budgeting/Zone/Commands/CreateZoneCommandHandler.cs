﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Zone.Commands;

public class CreateZoneCommandHandler :  IRequestHandler<CreateZoneCommand, ZoneCommandResponse>
{
    private readonly IZonePersistence _zonePersistence;
    private readonly IMapper _mapper;

    public CreateZoneCommandHandler(IZonePersistence zonePersistence, IMapper mapper)
    {
        _zonePersistence = zonePersistence;
        _mapper = mapper;
    }

    public async Task<ZoneCommandResponse> Handle(CreateZoneCommand request, CancellationToken cancellationToken)
    {
        var response = new ZoneCommandResponse();
        var zone = _mapper.Map<Domain.Entity.Budgeting.Zone>(request.Zone);

        var result = await _zonePersistence.AddAsync(zone);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<ZoneVm>(result.Entity);

        return response;
    }
}