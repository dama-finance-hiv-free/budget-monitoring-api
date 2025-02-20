using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SurgeActivity.Queries;

public class SurgeActivityQuery : IRequest<SurgeActivityVm>
{
    public string Code { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
}