namespace Domain.Events.Trainers;

public class TrainerUpdated : Event
{
    public required Guid TrainerId;
    public required string Name;
    public TrainerUpdated() : base("TrainerUpdated")
    {
    }
    
}