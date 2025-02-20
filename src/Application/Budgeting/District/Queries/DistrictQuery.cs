using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.District.Queries;

public class DistrictQuery : IRequest<DistrictVm>
{
    public string Tenant { get; set; }
    public string CopYear { get; set; }
    public string Region { get; set; }
    public string Code { get; set; }
    public string Project { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
}