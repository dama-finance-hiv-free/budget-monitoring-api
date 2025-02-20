using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Privilege.Commands;

public class CreatePrivilegeCommandHandler : 
    IRequestHandler<CreatePrivilegeCommand, PrivilegeCommandResponse>
{
    private readonly IPrivilegePersistence _privilegePersistence;
    private readonly IMapper _mapper;

    public CreatePrivilegeCommandHandler(IPrivilegePersistence privilegePersistence, IMapper mapper)
    {
        _privilegePersistence = privilegePersistence;
        _mapper = mapper;
    }

    public async Task<PrivilegeCommandResponse> Handle(CreatePrivilegeCommand request, CancellationToken cancellationToken)
    {
        var response = new PrivilegeCommandResponse();
        var privilege = _mapper.Map<Domain.Entity.Common.Privilege>(request.Privilege);

        var result = await _privilegePersistence.AddAsync(privilege);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<PrivilegeVm>(result.Entity);

        return response;
    }
}