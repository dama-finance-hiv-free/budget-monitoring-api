using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.CopYearIntervention.Commands;

public class CopYearInterventionCommandResponse : BaseResponse
{
    public CopYearInterventionVm Data { get; set; }
}