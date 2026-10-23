namespace WestCoastEducation.Models.Course;

public abstract class TeacherLeadCourse : BaseCourse
{
    public string? TeacherId { get; set; } //LärarId så att man ska kunna hitta läraren som ansvarar för kursen.

    protected TeacherLeadCourse(string? teacherId)
    {
        TeacherId = teacherId;
    }
}
