using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class TicketVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string UserCode { get; set; }
    public string UserEmail { get; set; }
    public string Status { get; set; }
    public string UserPhoneNumber { get; set; }
    public string Region { get; set; }
    public string Comment { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
}