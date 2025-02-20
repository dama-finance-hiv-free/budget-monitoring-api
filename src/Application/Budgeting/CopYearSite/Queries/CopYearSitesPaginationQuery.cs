using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearSite.Queries;

public class CopYearSitesPaginationQuery : IRequest<CopYearSiteVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}