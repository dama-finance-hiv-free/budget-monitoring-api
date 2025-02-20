using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Domain.Contracts.Service.Common;

public interface IMonthNameService : IServiceBase<MonthNameVm>
{
    Task<MonthNameVm[]> GetMonthNamesAsync(string lid);
}