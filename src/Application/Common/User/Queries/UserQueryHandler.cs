using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.User.Queries;

public class UserQueryHandler : RequestHandlerBase, IRequestHandler<UserQuery, UserVm>
{
    private readonly IUserService _userService;

    public UserQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UserVm> Handle(UserQuery request, CancellationToken cancellationToken) =>
        await _userService.GetAsync(request.Code, request.Code);
}