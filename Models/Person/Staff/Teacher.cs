using System.Text.Json.Serialization;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Course;

namespace WestCoastEducation.Models.Person.Staff;

public class Teacher : Person
{
    [JsonInclude]
    private List<string> _courseIds = new List<string>();
    [JsonIgnore]
    public List<TeacherLeadCourse> TeacherLeadCourses { get; set; } = [];
}
