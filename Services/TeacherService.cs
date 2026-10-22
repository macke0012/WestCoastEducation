using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Course;
using WestCoastEducation.Models.Person.Staff;

namespace WestCoastEducation.Services;

public class TeacherService(IStorageProvider db, CourseService courseService) : BaseService<Teacher>(db)
{
    protected override List<Teacher> Load() => Db.GetAll<Teacher>();

    protected override void LinkRelated(Teacher teacher) =>
        teacher.LoadCourses(courseService.GetAll<TeacherLeadCourse>());
}
