using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Site.Queries;

public class SiteQuery : IRequest<SiteVm>
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string Project { get; set; }
    public string Region { get; set; }
    public string Description { get; set; }
    public string District { get; set; }
    public string SiteType { get; set; }
    public string SiteTier { get; set; }
    public DateTime CreatedOn { get; set; }
}