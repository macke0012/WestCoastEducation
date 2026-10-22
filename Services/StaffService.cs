using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Person.Staff;

namespace WestCoastEducation.Services;

public class StaffService : IService<PermanentStaff>
{
    private IStorageProvider Db;
    private List<Administrator> Administrators = [];

    public StaffService(IStorageProvider _db)
    {
        Db = _db;
        LoadAll();
    }

    // Each staff type is saved in its own folder, so add new types here
    public void LoadAll()
    {
        Administrators = Db.GetAll<Administrator>();
    }

    public void Create(PermanentStaff obj)
    {
        Db.Save(obj);
        LoadAll();
    }

    public void Delete(string id)
    {
        Db.Delete(id);
        LoadAll();
    }

    public List<PermanentStaff> GetAll() => [.. Administrators];

    public PermanentStaff GetSingle(string id) =>
        GetAll().FirstOrDefault(s => s.Id == id) ?? throw new KeyNotFoundException($"Staff with id {id} not found");

    public List<T> GetAll<T>() where T : PermanentStaff => GetAll().OfType<T>().ToList();
}
