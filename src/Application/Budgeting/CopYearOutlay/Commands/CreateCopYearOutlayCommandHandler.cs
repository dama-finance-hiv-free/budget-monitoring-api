using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearOutlay.Commands;

public class CreateCopYearOutlayCommandHandler : IRequestHandler<CreateCopYearOutlayCommand, CopYearOutlayCommandResponse>
{
    private readonly ICopYearOutlayPersistence _CopYearOutlayPersistence;
    private readonly IMapper _mapper;

    public CreateCopYearOutlayCommandHandler(ICopYearOutlayPersistence CopYearOutlayPersistence, IMapper mapper)
    {
        _CopYearOutlayPersistence = CopYearOutlayPersistence;
        _mapper = mapper;
    }

    public async Task<CopYearOutlayCommandResponse> Handle(CreateCopYearOutlayCommand request, CancellationToken cancellationToken)
    {
        var response = new CopYearOutlayCommandResponse();
        var CopYearOutlay = _mapper.Map<Domain.Entity.Budgeting.CopYearOutlay>(request.CopYearOutlay);

        var result = await _CopYearOutlayPersistence.AddAsync(CopYearOutlay);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<CopYearOutlayVm>(result.Entity);

        return response;
    }
}