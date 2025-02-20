using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.MonthName.Commands;

public class EditMonthNameCommandHandler : IRequestHandler<EditMonthNameCommand, MonthNameCommandResponse>
{
    private readonly IMonthNamePersistence _monthNamePersistence;
    private readonly IMapper _mapper;

    public EditMonthNameCommandHandler(IMonthNamePersistence monthNamePersistence, IMapper mapper)
    {
        _monthNamePersistence = monthNamePersistence;
        _mapper = mapper;
    }

    public async Task<MonthNameCommandResponse> Handle(EditMonthNameCommand request, CancellationToken cancellationToken)
    {
        var response = new MonthNameCommandResponse();
        var monthName = _mapper.Map<Domain.Entity.Common.MonthName>(request.MonthName);

        var result = await _monthNamePersistence.EditAsync(monthName);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<MonthNameVm>(result.Entity);

        return response;
    }
}