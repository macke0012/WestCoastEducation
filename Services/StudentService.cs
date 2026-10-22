using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Person;

namespace WestCoastEducation.Services;

public class StudentService : IService<Student>
{
    private IStorageProvider Db;

    public StudentService(IStorageProvider db)
    {
        Db = db;
    }

    public void Create(Student student) => Db.Save(student);

    public void Update(Student student) => Db.Save(student);

    public void Delete(string id) => Db.Delete(id);

    public List<Student> GetAll() => Db.GetAll<Student>();

    public Student GetSingle(string id)
    {
        foreach (var student in GetAll())
        {
            if (student.Id == id)
            {
                return student;
            }
        }
        throw new KeyNotFoundException($"No student with id {id}");
    }
}
