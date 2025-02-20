using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.MonthName.Commands;

public abstract class MonthNameCommand : IRequest<MonthNameCommandResponse>
{
    public MonthNameVm MonthName { get; set; }
}