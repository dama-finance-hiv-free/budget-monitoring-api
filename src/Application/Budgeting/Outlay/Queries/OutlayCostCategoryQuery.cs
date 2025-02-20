using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Queries;

public class OutlayCostCategoryQuery : IRequest<OutlayCostCategoryDashboardVm>
{
    public OutlayOption Options { get; set; }
}
