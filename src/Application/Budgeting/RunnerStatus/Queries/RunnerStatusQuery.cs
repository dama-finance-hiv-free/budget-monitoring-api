using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerStatus.Queries;

public class RunnerStatusQuery : IRequest<RunnerStatusVm>
{
    public string Code { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
}