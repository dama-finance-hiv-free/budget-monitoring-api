using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYear.Commands;

public class EditCopYearCommandHandler : IRequestHandler<EditCopYearCommand, CopYearCommandResponse>
{
    private readonly ICopYearPersistence _copYearPersistence;
    private readonly IMapper _mapper;

    public EditCopYearCommandHandler(ICopYearPersistence copYearPersistence, IMapper mapper)
    {
        _copYearPersistence = copYearPersistence;
        _mapper = mapper;
    }

    public async Task<CopYearCommandResponse> Handle(EditCopYearCommand request, CancellationToken cancellationToken)
    {
        var response = new CopYearCommandResponse();
        var copYear = _mapper.Map<Domain.Entity.Budgeting.CopYear>(request.CopYear);

        var result = await _copYearPersistence.EditAsync(copYear);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<CopYearVm>(result.Entity);

        return response;
    }
}