﻿using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Target.Queries;

public class TargetQuery : IRequest<TargetVm>
{
    public string Tenant { get; set; }
    public string Outlay { get; set; }
    public string CopYear { get; set; }
    public string Project { get; set; }
    public string Component { get; set; }
    public string Region { get; set; }
    public double Target { get; set; }
    public DateTime CreatedOn { get; set; }
}