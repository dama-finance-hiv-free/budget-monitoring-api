using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Quarter.Queries;

public class QuarterQuery : IRequest<QuarterVm>
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string CopYear { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    public DateTime CreatedOn { get; set; }
}