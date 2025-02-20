using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.RoleMenu.Commands;

public class UpdateRoleMenuCommandHandler : IRequestHandler<UpdateRoleMenuCommand, RoleMenuCommandResponse>
{
    private readonly IRoleMenuPersistence _roleMenuPersistence;

    public UpdateRoleMenuCommandHandler(IRoleMenuPersistence roleMenuPersistence) 
    {
        _roleMenuPersistence = roleMenuPersistence;
    }

    public async Task<RoleMenuCommandResponse> Handle(UpdateRoleMenuCommand request,
        CancellationToken cancellationToken)
    {
        var response = new RoleMenuCommandResponse();
        var roleMenus = new RoleMenuDto
        {
            Tenant = request.RoleMenus.Tenant,
            Role = request.RoleMenus.Role,
            MenuCodes = request.RoleMenus.MenuCodes.Distinct().ToArray()
        };

        var result = await _roleMenuPersistence.UpdateRoleMenusAsync(roleMenus);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = roleMenus;

        return response;
    }
}