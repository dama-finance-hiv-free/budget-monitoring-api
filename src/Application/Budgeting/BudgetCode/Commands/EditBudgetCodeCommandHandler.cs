using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetCode.Commands;

public class EditBudgetCodeCommandHandler : IRequestHandler<EditBudgetCodeCommand, BudgetCodeCommandResponse>
{
    private readonly IBudgetCodePersistence _budgetCodePersistence;
    private readonly IMapper _mapper;

    public EditBudgetCodeCommandHandler(IBudgetCodePersistence budgetCodePersistence, IMapper mapper)
    {
        _budgetCodePersistence = budgetCodePersistence;
        _mapper = mapper;
    }

    public async Task<BudgetCodeCommandResponse> Handle(EditBudgetCodeCommand request, CancellationToken cancellationToken)
    {
        var response = new BudgetCodeCommandResponse();
        var budgetCode = _mapper.Map<Domain.Entity.Budgeting.BudgetCode>(request.BudgetCode);

        var result = await _budgetCodePersistence.EditAsync(budgetCode);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<BudgetCodeVm>(result.Entity);

        return response;
    }
}