using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.UserMenu.Commands;

public class UpdateUserRoleCommandHandler : 
    IRequestHandler<UpdateUserRoleCommand, UserRoleCommandResponse>
{
    private readonly IUserRolePersistence _userRolePersistence;
    private readonly IMapper _mapper;

    public UpdateUserRoleCommandHandler(IRolePersistence rolePersistence, IUserRolePersistence userRolePersistence, IMapper mapper) 
    {
        _userRolePersistence = userRolePersistence;
        _mapper = mapper;
    }

    public async Task<UserRoleCommandResponse> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var response = new UserRoleCommandResponse();
        var userRole = new UserRoleDto
        {
            Tenant = request.UserRoles.Tenant,
            User = request.UserRoles.User,
            Roles = request.UserRoles.Roles.Distinct().ToArray()
        };

        var result = await _userRolePersistence.UpdateUserRolesAsync(userRole);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.UserRoles = _mapper.Map<UserRoleVm[]>(result.Entity);

        return response;
    }
}