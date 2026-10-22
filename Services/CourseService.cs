using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Course;

namespace WestCoastEducation.Services;

public enum CourseType
{
    Remote,
    Classroom
}
public class CourseService : IService<BaseCourse>
{
    private IStorageProvider Db { get; set; }
    private List<RemoteCourse> RemoteCourses { get; set; } = [];
    private List<ClassroomCourse> ClassroomCourses { get; set; } = [];


    public CourseService(IStorageProvider db)
    {
        Db = db;
        LoadAll();
    }



    public void LoadAll()
    {
        RemoteCourses = Db.GetAll<RemoteCourse>();
        ClassroomCourses = Db.GetAll<ClassroomCourse>();
    }

    public void Create(BaseCourse course)
    {
        Db.Save(course);
        LoadAll();
    }

    public void Delete(string id)
    {
        Db.Delete(id);
        LoadAll();
    }

    public List<BaseCourse> GetAll() => [.. RemoteCourses, .. ClassroomCourses];

    public BaseCourse GetSingle(string id) =>
        GetAll().FirstOrDefault(c => c.Id == id) ?? throw new KeyNotFoundException($"Course with id {id} not found");

    // Only one kind of course, e.g. GetAll<RemoteCourse>()
    public List<T> GetAll<T>() where T : BaseCourse => GetAll().OfType<T>().ToList();

    public T GetSingle<T>(string id) where T : BaseCourse => (T)GetSingle(id);
}


