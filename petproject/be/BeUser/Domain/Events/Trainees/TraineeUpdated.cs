namespace Domain.Events.Trainees;

public class TraineeUpdated : Event
{
    public required Guid TraineeId;
    public required string Name;
    public TraineeUpdated() : base("TraineeUpdated")
    {
    }
    
}