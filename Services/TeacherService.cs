using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Person.Staff;

namespace WestCoastEducation.Services;

public class TeacherService : IService<Teacher>
{
    private IStorageProvider Db;
    private List<Teacher> Teachers = [];

    public TeacherService(IStorageProvider db)
    {
        Db = db;
        LoadAll();
    }

    public void LoadAll()
    {
        Teachers = Db.GetAll<Teacher>();
    }

    public void Create(Teacher teacher)
    {
        Db.Save(teacher);
        LoadAll();
    }

    public void Delete(string id)
    {
        Db.Delete(id);
        LoadAll();
    }

    public List<Teacher> GetAll() => [.. Teachers];

    public Teacher GetSingle(string id) =>
        Teachers.FirstOrDefault(t => t.Id == id) ?? throw new KeyNotFoundException($"Teacher with id {id} not found");
}
