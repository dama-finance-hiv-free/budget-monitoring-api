﻿using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.District.Commands;

public class DistrictCommandResponse : BaseResponse
{
    public DistrictVm Data { get; set; }
}