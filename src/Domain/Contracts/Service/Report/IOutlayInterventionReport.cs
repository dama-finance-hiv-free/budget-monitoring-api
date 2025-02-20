using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Report
{
    public interface IOutlayInterventionReport
    {
        byte[] Generate(OutlayInterventionVm[] outlayInterventionReport);
    }
}