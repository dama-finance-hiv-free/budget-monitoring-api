using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Project.Commands;

public class ProjectCommandResponse : BaseResponse
{
    public ProjectVm Data { get; set; }
}