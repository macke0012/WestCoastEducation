using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Person.Staff;

namespace WestCoastEducation.Services;

public class TeacherService : IService<Teacher>
{
    private IStorageProvider Db;

    public TeacherService(IStorageProvider db)
    {
        Db = db;
    }

    public void Create(Teacher teacher) => Db.Save(teacher);

    public void Update(Teacher teacher) => Db.Save(teacher);

    public void Delete(string id) => Db.Delete(id);

    public List<Teacher> GetAll() => Db.GetAll<Teacher>();

    public Teacher GetSingle(string id)
    {
        foreach (var teacher in GetAll())
        {
            if (teacher.Id == id)
            {
                return teacher;
            }
        }
        throw new KeyNotFoundException($"No teacher with id {id}");
    }
}
