using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SiteType.Commands;

public class CreateSiteTypeCommandHandler : IRequestHandler<CreateSiteTypeCommand, SiteTypeCommandResponse>
{
    private readonly ISiteTypePersistence _siteTypePersistence;
    private readonly IMapper _mapper;

    public CreateSiteTypeCommandHandler(ISiteTypePersistence siteTypePersistence, IMapper mapper)
    {
        _siteTypePersistence = siteTypePersistence;
        _mapper = mapper;
    }

    public async Task<SiteTypeCommandResponse> Handle(CreateSiteTypeCommand request, CancellationToken cancellationToken)
    {
        var response = new SiteTypeCommandResponse();
        var siteType = _mapper.Map<Domain.Entity.Budgeting.SiteType>(request.SiteType);

        var result = await _siteTypePersistence.AddAsync(siteType);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<SiteTypeVm>(result.Entity);

        return response;
    }
}