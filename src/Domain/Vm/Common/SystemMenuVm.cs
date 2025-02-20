using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class SystemMenuVm : IEntityBase
{
    public string Code { get; set; }
    public string Lid { get; set; }
    public string App { get; set; }
    public string Description { get; set; }
    public string Parent { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string Status { get; set; }
}