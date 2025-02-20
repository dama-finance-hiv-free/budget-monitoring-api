using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.User.Queries;

public class UsersQuery : IRequest<UserVm[]>
{

}