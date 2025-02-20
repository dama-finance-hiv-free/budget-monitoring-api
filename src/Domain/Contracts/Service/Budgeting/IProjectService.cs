using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IProjectService : IServiceBase<ProjectVm>
{
    Task<ProjectVm[]> GetProjectsAsync(string tenant);

    Task<string[]> GetProjectCodesAsync(string tenant);
}