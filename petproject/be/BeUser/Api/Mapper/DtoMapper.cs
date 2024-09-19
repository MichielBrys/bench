using Api.dto;
using Domain.Courses;

namespace Api.Mapper;

public static class DtoMapper
{
    public static CourseDTO MapCourseToCourseDto(Course course)
    {
        return new CourseDTO
        {
            CourseId = course.CourseId,
            Title = course.Title,
            Description = course.Description,
            Chapters = course.Chapters.Select(chapter => new ChapterDTO
            {
                ChapterId = chapter.ChapterId,
                Title = chapter.Title,
                Description = chapter.Description,
                MaterialUrl = chapter.MaterialUrl
            })
        };
    }
}