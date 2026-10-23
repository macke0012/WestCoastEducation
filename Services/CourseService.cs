using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Course;

namespace WestCoastEducation.Services;

public class CourseService : IService<BaseCourse>
{
    private IStorageProvider Db;

    public CourseService(IStorageProvider db)
    {
        Db = db;
    }

    public void Create(BaseCourse course) => Db.Save(course);

    public void Update(BaseCourse course) => Db.Save(course);

    public void Delete(string id) => Db.Delete(id);

    public List<BaseCourse> GetAll()
    {
        List<BaseCourse> courses = [];
        courses.AddRange(Db.GetAll<RemoteCourse>());
        courses.AddRange(Db.GetAll<ClassroomCourse>());
        return courses;
    }

    public BaseCourse GetSingle(string id)
    {
        foreach (var course in GetAll())
        {
            if (course.Id == id)
            {
                return course;
            }
        }
        throw new KeyNotFoundException($"No course with id {id}");
    }
}
