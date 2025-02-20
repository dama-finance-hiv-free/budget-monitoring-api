using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CostCategory.Commands;

public class EditCostCategoryCommandHandler : IRequestHandler<EditCostCategoryCommand, CostCategoryCommandResponse>
{
    private readonly ICostCategoryPersistence _costCategoryPersistence;
    private readonly IMapper _mapper;

    public EditCostCategoryCommandHandler(ICostCategoryPersistence costCategoryPersistence, IMapper mapper)
    {
        _costCategoryPersistence = costCategoryPersistence;
        _mapper = mapper;
    }

    public async Task<CostCategoryCommandResponse> Handle(EditCostCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = new CostCategoryCommandResponse();
        var costCategory = _mapper.Map<Domain.Entity.Budgeting.CostCategory>(request.CostCategory);

        var result = await _costCategoryPersistence.EditAsync(costCategory);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<CostCategoryVm>(result.Entity);

        return response;
    }
}