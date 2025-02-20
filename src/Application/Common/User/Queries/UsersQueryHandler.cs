using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.User.Queries;

public class UsersQueryHandler : RequestHandlerBase, IRequestHandler<UsersQuery, UserVm[]>
{
    private readonly IUserService _userService;

    public UsersQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UserVm[]> Handle(UsersQuery request, CancellationToken cancellationToken) =>
        await _userService.GetAllAsync(true);
}