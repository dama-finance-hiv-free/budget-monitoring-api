using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.MonthName.Queries;

public class MonthNamesQuery : IRequest<MonthNameVm[]>
{
    public string Lid { get; set; }
}