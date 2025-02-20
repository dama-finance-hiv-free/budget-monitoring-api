using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Domain.Contracts.Service.Common;

public interface IDateGenerationService : IServiceBase<DateGenerationVm>
{
    Task<DateGenerationVm[]> GetDateGenerationsAsync(string tenant);
}