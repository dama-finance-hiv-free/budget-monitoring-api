﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.AnnualTarget.Commands;

public class EditAnnualTargetCommandHandler : IRequestHandler<EditAnnualTargetCommand, AnnualTargetCommandResponse>
{
    private readonly IAnnualTargetPersistence _annualTargetPersistence;
    private readonly IMapper _mapper;

    public EditAnnualTargetCommandHandler(IAnnualTargetPersistence annualTargetPersistence, IMapper mapper)
    {
        _annualTargetPersistence = annualTargetPersistence;
        _mapper = mapper;
    }

    public async Task<AnnualTargetCommandResponse> Handle(EditAnnualTargetCommand request, CancellationToken cancellationToken)
    {
        var response = new AnnualTargetCommandResponse();
        var annualTarget = _mapper.Map<Domain.Entity.Budgeting.AnnualTarget>(request.AnnualTarget);


        var result = await _annualTargetPersistence.EditAsync(annualTarget);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<AnnualTargetVm>(result.Entity);

        return response;
    }
}