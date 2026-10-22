using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Person.Staff;

namespace WestCoastEducation.Models.Course;

public class TeacherLeadCourse : BaseCourse
{
    public string? TeacherId { get; set; }

    public TeacherLeadCourse(string? teacherId)
    {
        TeacherId = teacherId;
    }
}
