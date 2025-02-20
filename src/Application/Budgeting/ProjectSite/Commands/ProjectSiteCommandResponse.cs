using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.ProjectSite.Commands;

public class ProjectSiteCommandResponse : BaseResponse
{
    public ProjectSiteVm Data { get; set; }
}