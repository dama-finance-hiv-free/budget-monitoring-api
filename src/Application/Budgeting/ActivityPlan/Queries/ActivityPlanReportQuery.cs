using Dama.Fin.Domain.Vm;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ActivityPlan.Queries
{
    public class ActivityPlanReportQuery : IRequest<ReportFileVm>
    {
        public string Tenant { get; set; }
    }
}