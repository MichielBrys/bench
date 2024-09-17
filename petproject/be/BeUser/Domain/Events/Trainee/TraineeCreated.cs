namespace Domain.Events;

public class TraineeCreated : Event
{
    public required string NameTrainee;
    public required string NameAuthorizer;
    public string Type = "Create";

}