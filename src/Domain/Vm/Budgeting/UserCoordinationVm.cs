using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class UserCoordinationVm : IEntityBase
{
    public string User { get; set; }
    public string Coordination { get; set; }
    public DateTime CreatedOn { get; set; }
}