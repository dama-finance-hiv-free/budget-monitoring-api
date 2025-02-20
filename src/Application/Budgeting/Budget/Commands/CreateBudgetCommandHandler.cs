using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Budget.Commands;

public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand, BudgetCommandResponse>
{
    private readonly IBudgetPersistence _budgetPersistence;
    private readonly IMapper _mapper;

    public CreateBudgetCommandHandler(IBudgetPersistence budgetPersistence, IMapper mapper)
    {
        _budgetPersistence = budgetPersistence;
        _mapper = mapper;
    }

    public async Task<BudgetCommandResponse> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
    {
        var response = new BudgetCommandResponse();
        var budget = _mapper.Map<Domain.Entity.Budgeting.Budget>(request.Budget);

        var result = await _budgetPersistence.AddAsync(budget);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<BudgetVm>(result.Entity);

        return response;
    }
}