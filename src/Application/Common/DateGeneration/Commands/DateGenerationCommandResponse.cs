using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application.Common.DateGeneration.Commands;

public class DateGenerationCommandResponse : BaseResponse
{
    public DateGenerationVm Data { get; set; }
}