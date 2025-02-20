using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IOutlayService : IServiceBase<OutlayVm>
{
    Task<OutlayCostCategoryDashboardVm> GetOutlayCostCategory(OutlayOption options);
}