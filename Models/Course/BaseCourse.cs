using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Person.Staff;
using WestCoastEducation.Services;

namespace WestCoastEducation.Models.Course;

public abstract class BaseCourse : IStorageObject
{
    public required string CourseNumber { get; set; }
    public required string Title { get; set; }
    public required DateOnly StartDate { get; set; }
    public required DateOnly EndDate { get; set; }
    public required int DurationInWeeks { get; set; }
    public CourseType CourseType { get; set; }
    [JsonInclude]
    private string _teacherId { get; set; }
    [JsonIgnore]
    public Teacher? Teacher { get; set; }

    public string Id { get; init; } = Guid.NewGuid().ToString();

    public BaseCourse()
    {

        CourseType = GetCourseType();
    }

    private CourseType GetCourseType()
    {
        return GetType().Name switch
        {
            "RemoteCourse" => CourseType.Remote,
            "ClassroomCourse" => CourseType.Classroom,
            _ => throw new Exception("Invalid course type")
        };
    }

    public override string ToString() => $"Course Number: {CourseNumber}\nTitle: {Title}\nType: {CourseType}";
}
