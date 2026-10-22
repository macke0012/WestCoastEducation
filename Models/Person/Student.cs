using System.Text.Json.Serialization;
using WestCoastEducation.Models.Course;

namespace WestCoastEducation.Models.Person;

public class Student : Person
{
    // Only the course ids are saved, so each course stays in its own file
    [JsonInclude]
    public List<string> CourseIds { get; private set; } = [];

    [JsonIgnore]
    public List<BaseCourse> Courses { get; private set; } = [];

    /// <summary>
    /// Enrolls the student in a course
    /// </summary>
    /// <returns>False if the student was already enrolled</returns>
    public bool Enroll(BaseCourse course)
    {
        if (CourseIds.Contains(course.Id))
        {
            return false;
        }

        CourseIds.Add(course.Id);
        Courses.Add(course);
        return true;
    }

    /// <summary>
    /// Picks out the courses this student is enrolled in
    /// </summary>
    /// <param name="allCourses">Every saved course</param>
    public void LoadCourses(List<BaseCourse> allCourses)
    {
        Courses.Clear();
        foreach (var course in allCourses)
        {
            if (CourseIds.Contains(course.Id))
            {
                Courses.Add(course);
            }
        }
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
