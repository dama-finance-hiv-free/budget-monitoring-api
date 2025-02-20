using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Site.Commands;

public class CreateSiteCommandHandler : IRequestHandler<CreateSiteCommand, SiteCommandResponse>
{
    private readonly ISitePersistence _sitePersistence;
    private readonly IMapper _mapper;

    public CreateSiteCommandHandler(ISitePersistence sitePersistence, IMapper mapper)
    {
        _sitePersistence = sitePersistence;
        _mapper = mapper;
    }

    public async Task<SiteCommandResponse> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
    {
        var response = new SiteCommandResponse();
        var site = _mapper.Map<Domain.Entity.Budgeting.Site>(request.Site);

        var result = await _sitePersistence.AddAsync(site);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<SiteVm>(result.Entity);

        return response;
    }
}