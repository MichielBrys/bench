namespace Domain.Events;

public class Event
{
    public Guid StreamId { get; set; }
    public DateTime CreatedAt = DateTime.Now;
}