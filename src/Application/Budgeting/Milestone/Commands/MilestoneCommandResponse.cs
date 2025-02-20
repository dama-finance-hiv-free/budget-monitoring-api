using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Milestone.Commands;

public class MilestoneCommandResponse : BaseResponse
{
    public MilestoneVm Data { get; set; }
}