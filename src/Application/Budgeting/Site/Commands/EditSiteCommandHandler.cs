using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Site.Commands;

public class EditSiteCommandHandler : IRequestHandler<EditSiteCommand, SiteCommandResponse>
{
    private readonly ISitePersistence _sitePersistence;
    private readonly IMapper _mapper;

    public EditSiteCommandHandler(ISitePersistence sitePersistence, IMapper mapper)
    {
        _sitePersistence = sitePersistence;
        _mapper = mapper;
    }

    public async Task<SiteCommandResponse> Handle(EditSiteCommand request, CancellationToken cancellationToken)
    {
        var response = new SiteCommandResponse();
        var site = _mapper.Map<Domain.Entity.Budgeting.Site>(request.Site);

        var result = await _sitePersistence.EditAsync(site);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<SiteVm>(result.Entity);

        return response;
    }
}