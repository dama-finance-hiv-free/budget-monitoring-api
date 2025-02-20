using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Queries;

public class OutlayQuery : IRequest<OutlayVm>
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string BudgetCode { get; set; }
    public string Indicator { get; set; }
    public string Type { get; set; }
    public DateTime CreatedOn { get; set; }
}