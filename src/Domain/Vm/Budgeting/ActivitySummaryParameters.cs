namespace Dama.Fin.Domain.Vm.Budgeting;

public class ActivitySummaryParameters
{
    public string Tenant { get; set; }
    public string ActivityType { get; set; }
    public string Runner { get; set; }
    public string TransactionCode { get; set; }
    public string Project { get; set; }
}