namespace Domain.Events.Trainee;

public class TraineeCreated : Event
{
    public required string NameTrainee;
    public required string NameAuthorizer;
    

    public TraineeCreated() : base("TraineeCreated")
    {
    }
}