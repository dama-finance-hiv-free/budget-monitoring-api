using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.ServerStatus.Commands;

public class CreateServerStatusCommandHandler : IRequestHandler<CreateServerStatusCommand, ServerStatusCommandResponse>
{
    private readonly IServerStatusPersistence _serverStatusPersistence;
    private readonly IMapper _mapper;

    public CreateServerStatusCommandHandler(IServerStatusPersistence serverStatusPersistence, IMapper mapper)
    {
        _serverStatusPersistence = serverStatusPersistence;
        _mapper = mapper;
    }

    public async Task<ServerStatusCommandResponse> Handle(CreateServerStatusCommand request, CancellationToken cancellationToken)
    {
        var response = new ServerStatusCommandResponse();
        var serverStatus = _mapper.Map<Domain.Entity.Common.ServerStatus>(request.ServerStatus);

        var result = await _serverStatusPersistence.AddAsync(serverStatus);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<ServerStatusVm>(result.Entity);

        return response;
    }
}