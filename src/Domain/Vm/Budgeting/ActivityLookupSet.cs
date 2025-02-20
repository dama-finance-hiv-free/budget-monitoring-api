namespace Dama.Fin.Domain.Vm.Budgeting;

public class ActivityLookupSet
{
    public string[] Runners { get; set; }
    public string[] Components { get; set; }
    public string[] Branches { get; set; }
    public string[] UserCodes { get; set; }
    public string[] Activities { get; set; }
    public string[] CostCategories { get; set; }
    public string[] Interventions { get; set; }
    public string[] BudgetCodes { get; set; }
    public string[] Strategies { get; set; }
    public string[] TranCodes { get; set; }
    public string[] CopYears { get; set; }
    public string[] Regions { get; set; }
    public string[] Sites { get; set; }
    public string[] Projects { get; set; }
    public string[] ActivityTypes { get; set; }
    public string[] Batches { get; set; }
    public string[] BatchLines { get; set; }
    public string[] UserCoordination { get; set; }

    public ActivityUpdateMode ActivityUpdateMode { get; set; }
}

public enum ActivityUpdateMode
{
    Add,
    Edit
}