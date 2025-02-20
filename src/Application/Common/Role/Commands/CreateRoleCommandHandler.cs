using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Role.Commands;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RoleCommandResponse>
{
    private readonly IRolePersistence _rolePersistence;
    private readonly IMapper _mapper;

    public CreateRoleCommandHandler(IRolePersistence rolePersistence, IMapper mapper)
    {
        _rolePersistence = rolePersistence;
        _mapper = mapper;
    }

    public async Task<RoleCommandResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var response = new RoleCommandResponse();
        var role = _mapper.Map<Domain.Entity.Common.Role>(request.Role);

        var result = await _rolePersistence.AddAsync(role);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<RoleVm>(result.Entity);

        return response;
    }
}