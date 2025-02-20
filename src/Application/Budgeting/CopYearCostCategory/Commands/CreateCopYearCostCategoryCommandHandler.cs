using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearCostCategory.Commands;

public class CreateCopYearCostCategoryCommandHandler : IRequestHandler<CreateCopYearCostCategoryCommand, CopYearCostCategoryCommandResponse>
{
    private readonly ICopYearCostCategoryPersistence _copYearCostCategoryPersistence;
    private readonly IMapper _mapper;

    public CreateCopYearCostCategoryCommandHandler(ICopYearCostCategoryPersistence copYearCostCategoryPersistence, IMapper mapper)
    {
        _copYearCostCategoryPersistence = copYearCostCategoryPersistence;
        _mapper = mapper;
    }

    public async Task<CopYearCostCategoryCommandResponse> Handle(CreateCopYearCostCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = new CopYearCostCategoryCommandResponse();
        var copYearCostCategory = _mapper.Map<Domain.Entity.Budgeting.CopYearCostCategory>(request.CopYearCostCategory);

        var result = await _copYearCostCategoryPersistence.AddAsync(copYearCostCategory);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<CopYearCostCategoryVm>(result.Entity);

        return response;
    }
}