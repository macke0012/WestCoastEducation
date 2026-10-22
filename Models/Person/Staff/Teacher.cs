using System.Text.Json.Serialization;
using WestCoastEducation.Models.Course;

namespace WestCoastEducation.Models.Person.Staff;

public class Teacher : Person
{
    public string KnowledgeArea { get; set; } = "";

    // Not saved in the teacher file. Each course saves its teacher's id instead (see README).
    [JsonIgnore]
    public List<TeacherLeadCourse> Courses { get; private set; } = [];

    /// <summary>
    /// Picks out the courses this teacher is responsible for
    /// </summary>
    /// <param name="allCourses">Every course that can have a teacher</param>
    public void LoadCourses(List<TeacherLeadCourse> allCourses)
    {
        Courses.Clear();
        foreach (var course in allCourses)
        {
            if (course.TeacherId == Id)
            {
                Courses.Add(course);
            }
        }
    }

    public override string ToString()
    {
        string text = $"{base.ToString()}\nKnowledge Area: {KnowledgeArea}";

        if (Courses.Count == 0)
        {
            return text + "\nNot responsible for any courses";
        }

        text += "\nResponsible for:";
        foreach (var course in Courses)
        {
            text += $"\n\t{course.CourseNumber} {course.Title} ({course.CourseType})";
        }
        return text;
    }
}
