namespace Domain.Events;

public class Event
{
    public Guid StreamId { get; set; }
    public DateTime CreatedAt = DateTime.Now;
    public string Type { get; protected set; }

    public Event() { }

    protected Event(string eventType)
    {
        Type = eventType; 
    }}
    
    