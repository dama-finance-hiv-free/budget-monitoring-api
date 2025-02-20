using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class ServerStatusBaseVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Branch { get; set; }
    public DateTime? YearStart { get; set; }
    public DateTime? YearEnd { get; set; }
    public string TransYear { get; set; }
    public string Status { get; set; }
}