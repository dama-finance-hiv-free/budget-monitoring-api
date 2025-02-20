using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Quarter.Commands;

public class EditQuarterCommandHandler : IRequestHandler<EditQuarterCommand, QuarterCommandResponse>
{
    private readonly IQuarterPersistence _quarterPersistence;
    private readonly IMapper _mapper;

    public EditQuarterCommandHandler(IQuarterPersistence quarterPersistence, IMapper mapper)
    {
        _quarterPersistence = quarterPersistence;
        _mapper = mapper;
    }

    public async Task<QuarterCommandResponse> Handle(EditQuarterCommand request, CancellationToken cancellationToken)
    {
        var response = new QuarterCommandResponse();
        var quarter = _mapper.Map<Domain.Entity.Budgeting.Quarter>(request.Quarter);

        var result = await _quarterPersistence.EditAsync(quarter);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<QuarterVm>(result.Entity);

        return response;
    }
}