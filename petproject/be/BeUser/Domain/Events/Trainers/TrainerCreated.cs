namespace Domain.Events.Trainers;

public class TrainerCreated : Event
{
    public required string NameTrainer;
    public TrainerCreated() : base("TrainerCreated")
    {
    }
}