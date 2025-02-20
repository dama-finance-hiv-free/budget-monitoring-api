using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class ChartVm : IEntityBase
{
    public string Component { get; set; }
    public string[] Categories { get; set; }
    public ChartSeriesVm[] Series { get; set; }

}

public class ChartSeriesVm : IEntityBase
{
    public string Name { get; set; }
    public double[] Data { get; set; }
}