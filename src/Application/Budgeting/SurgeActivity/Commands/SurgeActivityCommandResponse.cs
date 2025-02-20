using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.SurgeActivity.Commands;

public class SurgeActivityCommandResponse : BaseResponse
{
    public SurgeActivityVm Data { get; set; }
}