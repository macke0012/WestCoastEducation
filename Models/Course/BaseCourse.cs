namespace WestCoastEducation.Models.Course;

public abstract class BaseCourse : IStorageObject
{
    public required string CourseNumber { get; set; }
    public required string Title { get; set; }
    public required DateOnly StartDate { get; set; }
    public required DateOnly EndDate { get; set; }
    public required int DurationInWeeks { get; set; }

    // Each course class says which type it is, so classroom and remote courses can be told apart
    public abstract CourseType CourseType { get; }

    public string Id { get; init; } = Guid.NewGuid().ToString();

    public override string ToString() =>
        $"Course Number: {CourseNumber}\nTitle: {Title}\nType: {CourseType}\nDates: {StartDate:yyyy-MM-dd} - {EndDate:yyyy-MM-dd} ({DurationInWeeks} weeks)";
}
