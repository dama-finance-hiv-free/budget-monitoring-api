using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponent.Queries;

public class RunnerComponentQuery : IRequest<RunnerComponentVm>
{
    public string Tenant { get; set; }
    public string Runner { get; set; }
    public string Project { get; set; }
    public string Component { get; set; }
    public DateTime CreatedOn { get; set; }
}