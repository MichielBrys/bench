using Domain.Progresses;

namespace Domain.Courses.Enrollments;

public class CourseEnrollment
{
    public Guid CourseEnrollmentId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public CourseState CourseState  { get; set; }
    
//    public Guid CourseId { get; set; } // Foreign Key
    public Course Course { get; set; }
    public Guid CourseId { get; set; }
    public ICollection<ChapterEnrollment> ChapterEnrollments { get; set; } = new List<ChapterEnrollment>();
    public ICollection<CourseProgress> CourseProgresses { get; set; } = new List<CourseProgress>();
    public ICollection<CourseEnrollmentTrainer> CourseEnrollmentTrainers { get; set; } = new List<CourseEnrollmentTrainer>();
    public ICollection<CourseEnrollmentTrainee> CourseEnrollmentTrainees { get; set; } = new List<CourseEnrollmentTrainee>();

}