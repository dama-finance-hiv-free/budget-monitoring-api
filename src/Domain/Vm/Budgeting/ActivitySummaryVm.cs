﻿using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class ActivitySummaryVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Batch { get; set; }
    public string Branch { get; set; }
    public string Runner { get; set; }
    public DateTime TransDate { get; set; }
    public string UserCode { get; set; }
    public string UsrName { get; set; }
    public double Amount { get; set; }
    public double Quantity { get; set; }
    public string Region { get; set; }
    public string Description { get; set; }
    public string Project { get; set; }
    public string ActivityType { get; set; }
    public string TransactionCode { get; set; }
    public string TransactionCodeDescription { get; set; }
}