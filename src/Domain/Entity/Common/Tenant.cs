using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Common;

public class Tenant: IIdentifiableEntity
{
    public string Code { get; set; }
    public string Description { get; set; }
    public string Telephone { get; set; }
    public string Fax { get; set; }
    public string Address { get; set; }
    public string PostBox { get; set; }
    public string City { get; set; }
    public string EMail { get; set; }
    public string Website { get; set; }
    public DateTime CreatedOn { get; set; }
}