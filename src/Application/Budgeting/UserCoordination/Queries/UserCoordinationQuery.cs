using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.UserCoordination.Queries;

public class UserCoordinationQuery : IRequest<UserCoordinationVm>
{
    public string User { get; set; }
    public string Coordination { get; set; }
    public DateTime CreatedOn { get; set; }
}