using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class DeletedActivityVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Batch { get; set; }
    public string BatchLine { get; set; }
}