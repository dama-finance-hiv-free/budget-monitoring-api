using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class ProjectSiteVm : IEntityBase
{
    public string Tenant { get; set; }
    public string copYear { get; set; }
    public string project { get; set; }
    public string site { get; set; }
    public DateTime CreatedOn { get; set; }
}