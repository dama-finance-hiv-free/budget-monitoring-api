using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class PrivilegeVm : IEntityBase
{
    public string Tenant { get; set; }
    public string MenCode { get; set; }

    public string UsrCode { get; set; }

    public string App { get; set; }

    public string Status { get; set; }

    public DateTime CreatedOn { get; set; }
}