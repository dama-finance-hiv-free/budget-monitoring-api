﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Intervention.Commands;

public class CreateInterventionCommandHandler : IRequestHandler<CreateInterventionCommand, InterventionCommandResponse>
{
    private readonly IInterventionPersistence _interventionPersistence;
    private readonly IMapper _mapper;

    public CreateInterventionCommandHandler(IInterventionPersistence interventionPersistence, IMapper mapper)
    {
        _interventionPersistence = interventionPersistence;
        _mapper = mapper;
    }

    public async Task<InterventionCommandResponse> Handle(CreateInterventionCommand request, CancellationToken cancellationToken)
    {
        var response = new InterventionCommandResponse();
        var intervention = _mapper.Map<Domain.Entity.Budgeting.Intervention>(request.Intervention);

        var result = await _interventionPersistence.AddAsync(intervention);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<InterventionVm>(result.Entity);

        return response;
    }
}