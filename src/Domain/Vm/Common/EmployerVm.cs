using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class EmployerVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Town { get; set; }
    public string Telephone { get; set; }
    public string Region { get; set; }
    public string Status { get; set; }
    public DateTime CreatedOn { get; set; }
}