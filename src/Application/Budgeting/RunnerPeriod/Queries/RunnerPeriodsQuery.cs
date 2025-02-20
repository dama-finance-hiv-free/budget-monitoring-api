using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriod.Queries;

public class RunnerPeriodsQuery : IRequest<RunnerPeriodVm[]>
{
    public string Tenant { get; set; }
}