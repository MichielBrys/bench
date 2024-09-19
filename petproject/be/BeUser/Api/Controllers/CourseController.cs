using Api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Service.Managers.Courses;

namespace Api.Controllers;

[ApiController]
[Route("api/course")]
public class CourseController : ControllerBase
{
    private readonly ICourseManager _courseService;

    public CourseController(ICourseManager courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public ActionResult GetCourses()
    {
        var courses = _courseService.GetCourses().Select(DtoMapper.MapCourseToCourseDto);
        return Ok(courses);
    }
}