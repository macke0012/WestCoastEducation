using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Person.Staff;

namespace WestCoastEducation.Services;

public class StaffService(IStorageProvider db, TeacherService teacherService) : BaseService<PermanentStaff>(db)
{
    // Each staff type is saved in its own folder, so add new types here
    protected override List<PermanentStaff> Load() =>
        [.. Db.GetAll<EducationLeader>(), .. Db.GetAll<Administrator>()];

    protected override void LinkRelated(PermanentStaff staff)
    {
        if (staff is EducationLeader leader)
        {
            leader.LoadTeachers(teacherService.GetAll());
        }
    }

    /// <summary>
    /// Makes an education leader responsible for a teacher and saves it
    /// </summary>
    public void AssignTeacher(EducationLeader leader, Teacher teacher)
    {
        leader.AssignTeacher(teacher);
        Update(leader);
    }
}
