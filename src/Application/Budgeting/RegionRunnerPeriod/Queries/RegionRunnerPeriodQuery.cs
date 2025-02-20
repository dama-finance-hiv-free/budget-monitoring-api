using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RegionRunnerPeriod.Queries;

public class RegionRunnerPeriodQuery : IRequest<RegionRunnerPeriodVm>
{
    public string Tenant { get; set; }
    public string Runner { get; set; }
    public string Region { get; set; }
    public DateTime CreatedOn { get; set; }
}