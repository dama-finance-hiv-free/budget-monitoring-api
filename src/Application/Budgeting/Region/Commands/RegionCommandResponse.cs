using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Region.Commands;

public class RegionCommandResponse : BaseResponse
{
    public RegionVm Data { get; set; }
}