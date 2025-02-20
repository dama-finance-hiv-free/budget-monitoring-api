using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Role.Commands;

public class EditRoleCommandHandler : IRequestHandler<EditRoleCommand, RoleCommandResponse>
{
    private readonly IRolePersistence _rolePersistence;
    private readonly IMapper _mapper;

    public EditRoleCommandHandler(IRolePersistence rolePersistence, IMapper mapper)
    {
        _rolePersistence = rolePersistence;
        _mapper = mapper;
    }

    public async Task<RoleCommandResponse> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var response = new RoleCommandResponse();
        var role = _mapper.Map<Domain.Entity.Common.Role>(request.Role);

        var result = await _rolePersistence.EditAsync(role);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<RoleVm>(result.Entity);

        return response;
    }
}