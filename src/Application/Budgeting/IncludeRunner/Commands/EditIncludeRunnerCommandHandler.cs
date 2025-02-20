using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.IncludeRunner.Commands;

public class EditIncludeRunnerCommandHandler : IRequestHandler<EditIncludeRunnerCommand, IncludeRunnerCommandResponse>
{
    private readonly IIncludeRunnerPersistence _includeRunnerPersistence;
    private readonly IMapper _mapper;

    public EditIncludeRunnerCommandHandler(IIncludeRunnerPersistence includeRunnerPersistence, IMapper mapper)
    {
        _includeRunnerPersistence = includeRunnerPersistence;
        _mapper = mapper;
    }

    public async Task<IncludeRunnerCommandResponse> Handle(EditIncludeRunnerCommand request, CancellationToken cancellationToken)
    {
        var response = new IncludeRunnerCommandResponse();
        var includeRunner = _mapper.Map<Domain.Entity.Budgeting.IncludeRunner>(request.IncludeRunner);

        var result = await _includeRunnerPersistence.EditAsync(includeRunner);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<IncludeRunnerVm>(result.Entity);

        return response;
    }
}