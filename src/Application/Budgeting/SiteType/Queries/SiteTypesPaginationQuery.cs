using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SiteType.Queries;

public class SiteTypesPaginationQuery : IRequest<SiteTypeVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}