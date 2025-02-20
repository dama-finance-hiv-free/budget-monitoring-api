using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Site.Queries;

public class SitesQuery : IRequest<SiteVm[]>
{
    public string Tenant { get; set; }
    public string Region { get; set; }
}
