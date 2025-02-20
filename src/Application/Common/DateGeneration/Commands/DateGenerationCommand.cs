using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.DateGeneration.Commands;

public abstract class DateGenerationCommand : IRequest<DateGenerationCommandResponse>
{
    public DateGenerationVm DateGeneration { get; set; }
}