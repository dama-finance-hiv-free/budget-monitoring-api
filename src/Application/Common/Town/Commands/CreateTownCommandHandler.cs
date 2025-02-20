using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Town.Commands;

public class CreateTownCommandHandler : IRequestHandler<CreateTownCommand, TownCommandResponse>
{
    private readonly ITownPersistence _townPersistence;
    private readonly IMapper _mapper;

    public CreateTownCommandHandler(ITownPersistence townPersistence, IMapper mapper)
    {
        _townPersistence = townPersistence;
        _mapper = mapper;
    }

    public async Task<TownCommandResponse> Handle(CreateTownCommand request, CancellationToken cancellationToken)
    {
        var response = new TownCommandResponse();
        var town = _mapper.Map<Domain.Entity.Common.Town>(request.Town);

        var result = await _townPersistence.AddAsync(town);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<TownVm>(result.Entity);

        return response;
    }
}