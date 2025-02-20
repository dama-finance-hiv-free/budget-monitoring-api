using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ProjectSite.Queries;

public class ProjectSiteQuery : IRequest<ProjectSiteVm>
{
    public string Tenant { get; set; }
    public string copYear { get; set; }
    public string site { get; set; }
    public string project { get; set; }
    public DateTime CreatedOn { get; set; }
}