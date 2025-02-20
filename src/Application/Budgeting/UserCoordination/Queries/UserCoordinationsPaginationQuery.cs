using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.UserCoordination.Queries;

public class UserCoordinationsPaginationQuery : IRequest<UserCoordinationVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}