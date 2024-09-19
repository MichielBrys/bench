using Domain.Courses.Enrollments;
using Domain.Events;
using Domain.Events.Trainers;

namespace Domain.Users;

public class Trainer
{
    public Guid TrainerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    public ICollection<Event> Events { get; }
    public ICollection<CourseEnrollmentTrainer> EnrollmentTrainers { get; set; } = new List<CourseEnrollmentTrainer>();
    
    
    public Trainer(string name, string email)
    {
        Name = name;
        Email = email;
        Events =
        [
            new TrainerCreated { NameTrainer = name }
        ];
    }
    
    public void UpdateName (String name)
    {
        Events.Add(new TrainerUpdated{TrainerId = TrainerId, Name = name});
        Name = name;
    }

}