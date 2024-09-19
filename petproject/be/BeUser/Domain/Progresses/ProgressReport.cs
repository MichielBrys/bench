namespace Domain.Progresses;

public class ProgressReport
{
    public Guid ProgressReportId { get; set; }
    public string Content { get; set; }
    public DateTime PublishDate { get; set; }
    public CourseProgress CourseProgress { get; set; }
    public Guid CourseProgressId { get; set; }
}