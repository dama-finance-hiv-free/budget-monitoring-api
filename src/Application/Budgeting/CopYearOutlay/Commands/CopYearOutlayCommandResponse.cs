using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.CopYearOutlay.Commands;

public class CopYearOutlayCommandResponse : BaseResponse
{
    public CopYearOutlayVm Data { get; set; }
}