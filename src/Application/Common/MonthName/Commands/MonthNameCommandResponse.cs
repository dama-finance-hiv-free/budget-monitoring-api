using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application.Common.MonthName.Commands;

public class MonthNameCommandResponse : BaseResponse
{
    public MonthNameVm Data { get; set; }
}