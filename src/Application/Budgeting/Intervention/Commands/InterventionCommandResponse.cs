using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Intervention.Commands;

public class InterventionCommandResponse : BaseResponse
{
    public InterventionVm Data { get; set; }
}