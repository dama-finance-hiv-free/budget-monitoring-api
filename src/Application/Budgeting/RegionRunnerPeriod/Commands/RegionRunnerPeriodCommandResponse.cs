using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.RegionRunnerPeriod.Commands;

public class RegionRunnerPeriodCommandResponse : BaseResponse
{
    public RegionRunnerPeriodVm Data { get; set; }
}