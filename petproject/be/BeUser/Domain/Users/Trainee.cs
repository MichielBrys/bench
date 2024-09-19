using Domain.Courses.Enrollments;
using Domain.Events;
using Domain.Events.Trainees;
using Domain.Progresses;

namespace Domain.Users;

public class Trainee
{
    public Guid TraineeId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<Event> Events { get; }
    public ICollection<CourseProgress> CourseProgresses { get; set;  }= new List<CourseProgress>();
    public ICollection<CourseEnrollmentTrainee> CourseEnrollmentTrainees { get; set; } = new List<CourseEnrollmentTrainee>();

    public Trainee(string name, string email)
    {
        Name = name;
        Email = email;
        Events =
        [
            new TraineeCreated { NameTrainee = name }
        ];
    }
  
    public void UpdateName (String name)
    {
        Events.Add(new TraineeUpdated{TraineeId = TraineeId, Name = name});
        Name = name;
    }
}