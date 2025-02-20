using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearIntervention.Commands;

public class CreateCopYearInterventionCommandHandler : IRequestHandler<CreateCopYearInterventionCommand, CopYearInterventionCommandResponse>
{
    private readonly ICopYearInterventionPersistence _copYearInterventionPersistence;
    private readonly IMapper _mapper;

    public CreateCopYearInterventionCommandHandler(ICopYearInterventionPersistence copYearInterventionPersistence, IMapper mapper)
    {
        _copYearInterventionPersistence = copYearInterventionPersistence;
        _mapper = mapper;
    }

    public async Task<CopYearInterventionCommandResponse> Handle(CreateCopYearInterventionCommand request, CancellationToken cancellationToken)
    {
        var response = new CopYearInterventionCommandResponse();
        var copYearIntervention = _mapper.Map<Domain.Entity.Budgeting.CopYearIntervention>(request.CopYearIntervention);

        var result = await _copYearInterventionPersistence.AddAsync(copYearIntervention);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<CopYearInterventionVm>(result.Entity);

        return response;
    }
}