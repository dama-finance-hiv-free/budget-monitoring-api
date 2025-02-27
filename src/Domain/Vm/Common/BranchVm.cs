﻿using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class BranchVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string Project { get; set; }
    public string BranchName { get; set; }
    public string BranchShortName { get; set; }
    public string StationCode { get; set; }
    public string Address { get; set; }
    public string Telephone { get; set; }
    public string Region { get; set; }
    public string HeadOffice { get; set; }
    public string Employer { get; set; }
    public string BranchType { get; set; }
    public string BranchTown { get; set; }
    public DateTime CreatedOn { get; set; }
}