namespace Domain.Events.Trainee;

public class TraineeCreated : Event
{
    public required string NameTrainee;
    

    public TraineeCreated() : base("TraineeCreated")
    {
    }
}