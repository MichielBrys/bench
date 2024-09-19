using Domain.Courses;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Service.Managers.Courses;

public class CourseManager : ICourseManager
{

    private readonly BenchDbContext _context;

    public CourseManager(BenchDbContext context)
    {
        _context = context;
    }
    public  IEnumerable<Course> GetCourses()
    {
        return  _context.Courses.Include(c => c.Chapters);
    }
}