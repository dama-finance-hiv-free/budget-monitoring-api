using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.District.Queries;

public class DistrictsPaginationQuery : IRequest<DistrictVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}