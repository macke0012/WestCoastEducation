namespace WestCoastEducation.Models.Course;

// A course a teacher is responsible for. Only the teacher's id is saved, so the teacher isn't copied into every course file.
public abstract class TeacherLeadCourse : BaseCourse
{
    public string? TeacherId { get; set; }

    protected TeacherLeadCourse(string? teacherId)
    {
        TeacherId = teacherId;
    }
}
