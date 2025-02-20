﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearSite.Commands;

public class CreateCopYearSiteCommandHandler : IRequestHandler<CreateCopYearSiteCommand, CopYearSiteCommandResponse>
{
    private readonly ICopYearSitePersistence _copYearSitePersistence;
    private readonly IMapper _mapper;

    public CreateCopYearSiteCommandHandler(ICopYearSitePersistence copYearSitePersistence, IMapper mapper)
    {
        _copYearSitePersistence = copYearSitePersistence;
        _mapper = mapper;
    }

    public async Task<CopYearSiteCommandResponse> Handle(CreateCopYearSiteCommand request, CancellationToken cancellationToken)
    {
        var response = new CopYearSiteCommandResponse();
        var copYearSite = _mapper.Map<Domain.Entity.Budgeting.CopYearSite>(request.CopYearSite);

        var result = await _copYearSitePersistence.AddAsync(copYearSite);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<CopYearSiteVm>(result.Entity);

        return response;
    }
}