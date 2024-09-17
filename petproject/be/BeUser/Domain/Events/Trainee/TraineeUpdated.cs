namespace Domain.Events;

public class TraineeUpdated : Event
{
    public required int TraineeId;
    public required string Name;
    public string Type = "Update";
}