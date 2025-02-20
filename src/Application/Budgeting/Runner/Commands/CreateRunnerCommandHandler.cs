using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Runner.Commands;

public class CreateRunnerCommandHandler : RequestHandlerBase, IRequestHandler<CreateRunnerCommand, RunnerCommandResponse>
{
    private readonly IRunnerPersistence _runnerPersistence;
    private readonly IRegionService _regionService;
    private readonly IRunnerPeriodService _runnerPeriodService;
    private readonly IMapper _mapper;

    public CreateRunnerCommandHandler(IRunnerPersistence runnerPersistence, IRegionService regionService,
        IRunnerPeriodService runnerPeriodService, IMapper mapper)
    {
        _runnerPersistence = runnerPersistence;
        _regionService = regionService;
        _runnerPeriodService = runnerPeriodService;
        _mapper = mapper;
    }

    public async Task<RunnerCommandResponse> Handle(CreateRunnerCommand request, CancellationToken cancellationToken)
    {
        var response = new RunnerCommandResponse();
        var runner = _mapper.Map<Domain.Entity.Budgeting.Runner>(request.Runner);

        var result = await _runnerPersistence.AddAsync(request.Tenant, runner.Code, runner.Region, runner.Project);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<RunnerVm>(result.Entity);

        return response;
    }
}