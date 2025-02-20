using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearIntervention.Queries;

public class CopYearInterventionQuery : IRequest<CopYearInterventionVm>
{
    public string Tenant { get; set; }
    public string CopYear { get; set; }
    public string Project { get; set; }
    public string Intervention { get; set; }
}