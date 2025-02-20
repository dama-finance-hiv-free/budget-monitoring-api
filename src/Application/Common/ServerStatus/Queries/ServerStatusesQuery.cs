using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.ServerStatus.Queries;

public class ServerStatusesQuery : IRequest<ServerStatusVm[]>
{

}