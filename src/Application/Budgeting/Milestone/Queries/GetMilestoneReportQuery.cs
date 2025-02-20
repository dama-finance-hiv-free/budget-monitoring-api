using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Milestone.Queries;

public class GetMilestoneReportQuery : IRequest<ReportFileVm>
{
    public MilestoneDasboardOptions Options { get; set; }
}