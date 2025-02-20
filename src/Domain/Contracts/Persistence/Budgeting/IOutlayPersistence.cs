using System;
using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IOutlayPersistence : IDataPersistence<Outlay>
{
    Task<Outlay[]> GetOutlaysAsync(string tenant);
    Task<OutlayDashVm[]> GetOutlayDashAsync(string tenant, string region);
    Task<OutlayDashVm[]> GetOutlayTargetAsync(string tenant, string region);
    Task<OutlayDashVm[]> GetOutlayAnalysisAsync(string tenant, string region, DateTime startDate, DateTime endDate);
    Task<OutlayDashVm[]> GetOutlayDashAsync(string tenant, string region, string component, string copYear);
    Task<OutlayCostCategoryDashboardVm> GetOutlayCostCategory(OutlayOption options);
}
