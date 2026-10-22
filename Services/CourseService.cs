using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Course;

namespace WestCoastEducation.Services;

public class CourseService(IStorageProvider db) : BaseService<BaseCourse>(db)
{
    // Remote and classroom courses are saved in separate folders
    protected override List<BaseCourse> Load() =>
        [.. Db.GetAll<RemoteCourse>(), .. Db.GetAll<ClassroomCourse>()];
}
