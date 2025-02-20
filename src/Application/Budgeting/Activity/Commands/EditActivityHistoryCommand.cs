namespace Dama.Fin.Application.Budgeting.Activity.Commands;

public class EditActivityHistoryCommand : ActivityHistoryCommand 
{
    public string Tenant { get; set; }
}