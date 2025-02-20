using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Project.Queries;

public class ProjectsPaginationQuery : IRequest<ProjectVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}