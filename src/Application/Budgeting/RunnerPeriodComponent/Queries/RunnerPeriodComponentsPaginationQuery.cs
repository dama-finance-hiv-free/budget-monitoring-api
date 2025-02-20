﻿using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodComponent.Queries;

public class RunnerPeriodComponentsPaginationQuery : IRequest<RunnerPeriodComponentVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}