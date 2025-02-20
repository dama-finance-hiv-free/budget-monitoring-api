using Dama.Fin.Domain.Vm;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Queries;

public class OutlayAnalysisReportQuery : IRequest<ReportFileVm>
{
    public OutlayAnalysisOptions Options { get; set; }
}
