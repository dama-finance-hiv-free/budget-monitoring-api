using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.DateGeneration.Queries;

public class DateGenerationQuery : IRequest<DateGenerationVm>
{
    public string Tenant { get; set; }
    public string Code { get; set; }
}