using Dama.Fin.Domain.Vm.Budgeting;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Week.Queries;

public class WeeksQuery : IRequest<WeekVm[]>
{
    public string Tenant { get; set; }
    public WeekParams Params { get; set; }
}