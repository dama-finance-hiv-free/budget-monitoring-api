using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Queries
{
    public class OutlayCostCategoryQueryHandler : RequestHandlerBase, IRequestHandler<OutlayCostCategoryQuery, OutlayCostCategoryDashboardVm>
    {
        private readonly IOutlayService _outlayService;

        public OutlayCostCategoryQueryHandler(IOutlayService outlayDomainService) => _outlayService = outlayDomainService;

        public async Task<OutlayCostCategoryDashboardVm> Handle(OutlayCostCategoryQuery request, CancellationToken cancellationToken) => 
            await _outlayService.GetOutlayCostCategory(request.Options);
    }
}