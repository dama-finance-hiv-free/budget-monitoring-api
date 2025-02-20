using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearOutlay.Queries;

public class CopYearOutlayQuery : IRequest<CopYearOutlayVm>
{
    public string Tenant { get; set; }
    public string CopYear { get; set; }
    public string Project { get; set; }
    public string Outlay { get; set; }
}