using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RegionRunnerPeriod.Commands;

public abstract class RegionRunnerPeriodCommand : IRequest<RegionRunnerPeriodCommandResponse>
{
    public RegionRunnerPeriodVm RegionRunnerPeriod { get; set; }
}