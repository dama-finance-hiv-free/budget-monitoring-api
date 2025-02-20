using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.MonthName.Queries;

public class MonthNameQuery : IRequest<MonthNameVm>
{
    public string Tenant { get; set; }
    public string Code { get; set; }
}