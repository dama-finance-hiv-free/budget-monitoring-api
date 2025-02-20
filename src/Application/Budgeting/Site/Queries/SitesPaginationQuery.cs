using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Site.Queries;

public class SitesPaginationQuery : IRequest<SiteVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}