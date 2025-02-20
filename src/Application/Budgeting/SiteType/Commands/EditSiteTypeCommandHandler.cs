using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SiteType.Commands;

public class EditSiteTypeCommandHandler : IRequestHandler<EditSiteTypeCommand, SiteTypeCommandResponse>
{
    private readonly ISiteTypePersistence _siteTypePersistence;
    private readonly IMapper _mapper;

    public EditSiteTypeCommandHandler(ISiteTypePersistence siteTypePersistence, IMapper mapper)
    {
        _siteTypePersistence = siteTypePersistence;
        _mapper = mapper;
    }

    public async Task<SiteTypeCommandResponse> Handle(EditSiteTypeCommand request, CancellationToken cancellationToken)
    {
        var response = new SiteTypeCommandResponse();
        var siteType = _mapper.Map<Domain.Entity.Budgeting.SiteType>(request.SiteType);

        var result = await _siteTypePersistence.EditAsync(siteType);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<SiteTypeVm>(result.Entity);

        return response;
    }
}