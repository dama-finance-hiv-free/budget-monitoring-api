using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Town.Queries;

public class TownQuery : IRequest<TownVm>
{
    public string Code { get; set; }
}