using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class MonthNameVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Code { get; set; }

    public string Lid { get; set; }

    public string Description { get; set; }

    public DateTime CreatedOn { get; set; }
}
