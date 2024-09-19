using Domain.Courses;

namespace Service.Managers.Courses;

public interface ICourseManager
{
    public IEnumerable<Course> GetCourses();
}