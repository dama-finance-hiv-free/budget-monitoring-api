using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Budget.Commands;

public class EditBudgetCommandHandler : IRequestHandler<EditBudgetCommand, BudgetCommandResponse>
{
    private readonly IBudgetPersistence _budgetPersistence;
    private readonly IMapper _mapper;

    public EditBudgetCommandHandler(IBudgetPersistence budgetPersistence, IMapper mapper)
    {
        _budgetPersistence = budgetPersistence;
        _mapper = mapper;
    }

    public async Task<BudgetCommandResponse> Handle(EditBudgetCommand request, CancellationToken cancellationToken)
    {
        var response = new BudgetCommandResponse();
        var budget = _mapper.Map<Domain.Entity.Budgeting.Budget>(request.Budget);

        var result = await _budgetPersistence.EditAsync(budget);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<BudgetVm>(result.Entity);

        return response;
    }
}