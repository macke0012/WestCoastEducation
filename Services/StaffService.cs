using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Person.Staff;

namespace WestCoastEducation.Services;

public class StaffService : IService<PermanentStaff>
{
    private IStorageProvider Db;

    public StaffService(IStorageProvider db)
    {
        Db = db;
    }

    public void Create(PermanentStaff staff) => Db.Save(staff);

    public void Update(PermanentStaff staff) => Db.Save(staff);

    public void Delete(string id) => Db.Delete(id);

    public List<PermanentStaff> GetAll()
    {
        List<PermanentStaff> staff = [];
        staff.AddRange(Db.GetAll<EducationLeader>());
        staff.AddRange(Db.GetAll<Administrator>());
        return staff;
    }

    public PermanentStaff GetSingle(string id)
    {
        foreach (var person in GetAll())
        {
            if (person.Id == id)
            {
                return person;
            }
        }
        throw new KeyNotFoundException($"No staff with id {id}");
    }
}
