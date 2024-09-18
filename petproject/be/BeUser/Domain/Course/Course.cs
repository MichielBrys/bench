using Domain.Course.Enrollments;

namespace Domain.Course;

public class Course
{
    public Guid CourseId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
    public ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();
}