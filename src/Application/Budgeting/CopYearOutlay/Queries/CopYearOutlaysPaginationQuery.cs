using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearOutlay.Queries;

public class CopYearOutlaysPaginationQuery : IRequest<CopYearOutlayVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}