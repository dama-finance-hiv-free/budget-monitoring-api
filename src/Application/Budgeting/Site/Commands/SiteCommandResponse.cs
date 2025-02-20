using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Site.Commands;

public class SiteCommandResponse : BaseResponse
{
    public SiteVm Data { get; set; }
}