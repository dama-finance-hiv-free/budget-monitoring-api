using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Report
{
    public interface IOutlayCostCategoryReport
    {
        byte[] Generate(OutlayCostCategoryVm[] outlayCostCategoryReport);
    }
}