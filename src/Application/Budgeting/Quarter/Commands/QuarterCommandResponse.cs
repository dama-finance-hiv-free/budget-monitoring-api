using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Quarter.Commands;

public class QuarterCommandResponse : BaseResponse
{
    public QuarterVm Data { get; set; }
}