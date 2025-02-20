using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.SiteType.Commands;

public class SiteTypeCommandResponse : BaseResponse
{
    public SiteTypeVm Data { get; set; }
}