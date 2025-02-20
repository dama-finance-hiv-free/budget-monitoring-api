using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.SystemMenu.Commands;

public class CreateSystemMenuCommandHandler : IRequestHandler<CreateSystemMenuCommand, SystemMenuCommandResponse>
{
    private readonly ISystemMenuPersistence _systemMenuPersistence;
    private readonly IMapper _mapper;

    public CreateSystemMenuCommandHandler(ISystemMenuPersistence systemMenuPersistence, IMapper mapper)
    {
        _systemMenuPersistence = systemMenuPersistence;
        _mapper = mapper;
    }

    public async Task<SystemMenuCommandResponse> Handle(CreateSystemMenuCommand request, CancellationToken cancellationToken)
    {
        var response = new SystemMenuCommandResponse();
        var systemMenu = _mapper.Map<Domain.Entity.Common.SystemMenu>(request.SystemMenu);

        var result = await _systemMenuPersistence.AddAsync(systemMenu);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<SystemMenuVm>(result.Entity);

        return response;
    }
}