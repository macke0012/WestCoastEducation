using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Course;
using WestCoastEducation.Models.Person;

namespace WestCoastEducation.Services;

public class StudentService(IStorageProvider db, CourseService courseService) : BaseService<Student>(db)
{
    protected override List<Student> Load() => Db.GetAll<Student>();

    protected override void LinkRelated(Student student) =>
        student.LoadCourses(courseService.GetAll());

    /// <summary>
    /// Enrolls a student in a course and saves it. Does nothing if they are already enrolled.
    /// </summary>
    public void Enroll(Student student, BaseCourse course)
    {
        if (student.Enroll(course))
        {
            Update(student);
        }
    }
}
