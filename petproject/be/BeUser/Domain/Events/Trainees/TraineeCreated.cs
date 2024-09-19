namespace Domain.Events.Trainees;

public class TraineeCreated : Event
{
    public required string NameTrainee;
    

    public TraineeCreated() : base("TraineeCreated")
    {
    }
}