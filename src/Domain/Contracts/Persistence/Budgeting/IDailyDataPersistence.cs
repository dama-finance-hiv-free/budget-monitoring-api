using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IDailyDataPersistence : IDataPersistence<PrintDailyData>
{
    Task<DailyDataVm[]> GetDailyDataAsync(DailyDataOptions options);
}
