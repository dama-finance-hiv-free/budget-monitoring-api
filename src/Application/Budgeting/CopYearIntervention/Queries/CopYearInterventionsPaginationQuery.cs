using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearIntervention.Queries;

public class CopYearInterventionsPaginationQuery : IRequest<CopYearInterventionVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}