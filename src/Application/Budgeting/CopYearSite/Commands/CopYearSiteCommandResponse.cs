using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.CopYearSite.Commands;

public class CopYearSiteCommandResponse : BaseResponse
{
    public CopYearSiteVm Data { get; set; }
}