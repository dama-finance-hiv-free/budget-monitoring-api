using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IQuarterService : IServiceBase<QuarterVm>
{
    Task<QuarterVm[]> GetQuartersAsync(string tenant);
}