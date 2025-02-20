using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriod.Queries;

public class RunnerPeriodHistoryCodesQuery : IRequest<string[]>
{
    public string Tenant { get; set; }
    public string Project { get; set; }
    public string Region { get; set; }
    public string CopYear { get; set; }
}