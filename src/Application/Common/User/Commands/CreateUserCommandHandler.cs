using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.User.Commands;

public class CreateUserCommandHandler :  IRequestHandler<CreateUserCommand, UserCommandResponse>
{
    private readonly IUserPersistence _userPersistence;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserPersistence userPersistence, IMapper mapper)
    {
        _userPersistence = userPersistence;
        _mapper = mapper;
    }

    public async Task<UserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var response = new UserCommandResponse();
        var user = _mapper.Map<Domain.Entity.Common.User>(request.User);

        var result = await _userPersistence.AddAsync(user);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<UserVm>(result.Entity);

        return response;
    }
}