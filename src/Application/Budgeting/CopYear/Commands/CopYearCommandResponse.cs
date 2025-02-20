using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.CopYear.Commands;

public class CopYearCommandResponse : BaseResponse
{
    public CopYearVm Data { get; set; }
}