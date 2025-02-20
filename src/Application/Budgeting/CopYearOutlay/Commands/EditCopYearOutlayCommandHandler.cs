using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearOutlay.Commands;

public class EditCopYearOutlayCommandHandler : IRequestHandler<EditCopYearOutlayCommand, CopYearOutlayCommandResponse>
{
    private readonly ICopYearOutlayPersistence _copYearOutlayPersistence;
    private readonly IMapper _mapper;

    public EditCopYearOutlayCommandHandler(ICopYearOutlayPersistence copYearOutlayPersistence, IMapper mapper)
    {
        _copYearOutlayPersistence = copYearOutlayPersistence;
        _mapper = mapper;
    }

    public async Task<CopYearOutlayCommandResponse> Handle(EditCopYearOutlayCommand request, CancellationToken cancellationToken)
    {
        var response = new CopYearOutlayCommandResponse();
        var copYearOutlay = _mapper.Map<Domain.Entity.Budgeting.CopYearOutlay>(request.CopYearOutlay);

        var result = await _copYearOutlayPersistence.EditAsync(copYearOutlay);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<CopYearOutlayVm>(result.Entity);

        return response;
    }
}