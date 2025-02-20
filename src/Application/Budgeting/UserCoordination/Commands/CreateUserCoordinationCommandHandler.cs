using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.UserCoordination.Commands;

public class CreateUserCoordinationCommandHandler : IRequestHandler<CreateUserCoordinationCommand, UserCoordinationCommandResponse>
{
    private readonly IUserCoordinationPersistence _userCoordinationPersistence;
    private readonly IMapper _mapper;

    public CreateUserCoordinationCommandHandler(IUserCoordinationPersistence userCoordinationPersistence, IMapper mapper)
    {
        _userCoordinationPersistence = userCoordinationPersistence;
        _mapper = mapper;
    }

    public async Task<UserCoordinationCommandResponse> Handle(CreateUserCoordinationCommand request, CancellationToken cancellationToken)
    {
        var response = new UserCoordinationCommandResponse();
        var userCoordination = _mapper.Map<Domain.Entity.Budgeting.UserCoordination>(request.UserCoordination);

        var result = await _userCoordinationPersistence.UpdateUserCoordination(userCoordination);

        if(result.Status != RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null;
            response.UserCoordinations = null;

            return response;
        }

        response.UserCoordinations = _mapper.Map<UserCoordinationVm[]>(result.Entity);

        return response;
    }
}