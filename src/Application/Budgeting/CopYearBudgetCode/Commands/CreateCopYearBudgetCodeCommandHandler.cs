using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearBudgetCode.Commands;

public class CreateCopYearBudgetCodeCommandHandler : IRequestHandler<CreateCopYearBudgetCodeCommand, CopYearBudgetCodeCommandResponse>
{
    private readonly ICopYearBudgetCodePersistence _copYearBudgetCodePersistence;
    private readonly IMapper _mapper;

    public CreateCopYearBudgetCodeCommandHandler(ICopYearBudgetCodePersistence copYearBudgetCodePersistence, IMapper mapper)
    {
        _copYearBudgetCodePersistence = copYearBudgetCodePersistence;
        _mapper = mapper;
    }

    public async Task<CopYearBudgetCodeCommandResponse> Handle(CreateCopYearBudgetCodeCommand request, CancellationToken cancellationToken)
    {
        var response = new CopYearBudgetCodeCommandResponse();
        var copYearBudgetCode = _mapper.Map<Domain.Entity.Budgeting.CopYearBudgetCode>(request.CopYearBudgetCode);

        var result = await _copYearBudgetCodePersistence.AddAsync(copYearBudgetCode);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<CopYearBudgetCodeVm>(result.Entity);

        return response;
    }
}