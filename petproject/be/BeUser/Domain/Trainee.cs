using Domain.Events;

namespace Domain;

public class Trainee
{
    public int TraineeId { get; set; }
    public string Name { get; set; }
    public List<Event> Events { get; set; }

    public void Append(Event @event)
    {
        Events.Add(@event);
    }
    public void Apply(TraineeUpdated traineeUpdated)
    {
        Name = traineeUpdated.Name;
    }
}