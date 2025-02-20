using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearSite.Queries;

public class CopYearSiteQuery : IRequest<CopYearSiteVm>
{
    public string Tenant { get; set; }
    public string CopYearSite { get; set; }
    public string Project { get; set; }
    public string Site { get; set; }
}