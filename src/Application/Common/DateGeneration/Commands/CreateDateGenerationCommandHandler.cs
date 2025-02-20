using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.DateGeneration.Commands;

public class CreateDateGenerationCommandHandler : IRequestHandler<CreateDateGenerationCommand, DateGenerationCommandResponse>
{
    private readonly IDateGenerationPersistence _dateGenerationPersistence;
    private readonly IMapper _mapper;

    public CreateDateGenerationCommandHandler(IDateGenerationPersistence dateGenerationPersistence, IMapper mapper)
    {
        _dateGenerationPersistence = dateGenerationPersistence;
        _mapper = mapper;
    }

    public async Task<DateGenerationCommandResponse> Handle(CreateDateGenerationCommand request, CancellationToken cancellationToken)
    {
        var response = new DateGenerationCommandResponse();
        var dateGeneration = _mapper.Map<Domain.Entity.Common.DateGeneration>(request.DateGeneration);

        var result = await _dateGenerationPersistence.AddAsync(dateGeneration);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<DateGenerationVm>(result.Entity);

        return response;
    }
}