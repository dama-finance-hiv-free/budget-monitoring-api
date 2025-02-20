using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYear.Queries;

public class CopYearsPaginationQuery : IRequest<CopYearVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}