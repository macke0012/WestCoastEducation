using System.Text.Json.Serialization;
using WestCoastEducation.Models.Course;

namespace WestCoastEducation.Models.Person.Staff;

public class Teacher : Person
{
    public string KnowledgeArea { get; set; } = "";

    // The courses are saved inside the teacher's file
    [JsonInclude]
    public List<BaseCourse> Courses { get; private set; } = [];

    public void AddCourse(BaseCourse course)
    {
        if (Courses.Any(c => c.Id == course.Id))
        {
            return; // Already responsible for this course
        }
        Courses.Add(course);
    }

    public void RemoveCourse(BaseCourse course)
    {
        Courses.RemoveAll(c => c.Id == course.Id);
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
