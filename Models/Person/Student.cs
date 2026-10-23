using System.Text.Json.Serialization;
using WestCoastEducation.Models.Course;

namespace WestCoastEducation.Models.Person;

public class Student : Person
{
    [JsonInclude]
    public List<BaseCourse> Courses { get; private set; } = [];

    public void Enroll(BaseCourse course)
    {
        if (Courses.Any(c => c.Id == course.Id))
        {
            return;
        }
        Courses.Add(course);
    }

    public void Unenroll(BaseCourse course)
    {
        Courses.RemoveAll(c => c.Id == course.Id);
    }

    public override string ToString()
    {
        string text = base.ToString();

        if (Courses.Count == 0)
        {
            return text + "\nNot enrolled in any courses";
        }

        foreach (var course in Courses)
        {
            text += $"\nCourse: {course.CourseNumber}\n\t{course.Title}\n\tDuration: {course.DurationInWeeks} weeks";
        }
        return text;
    }
}
