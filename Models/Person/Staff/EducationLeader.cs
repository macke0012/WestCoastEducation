namespace WestCoastEducation.Models.Person.Staff;

public class EducationLeader
{
    private List<Teacher> _responsibleTeachers = new List<Teacher>();
    public IReadOnlyCollection<Teacher> ResponsibleTeachers => _responsibleTeachers;

    /// <summary>
    /// Assigns a teacher to the education leader only if the teacher is not already assigned to the education leader
    /// </summary>
    /// <param name="teacher">The teacher to assign</param>
    public void AssignTeacher(Teacher teacher)
    {
        if (IsTeacherAssigned(teacher)) return;
        _responsibleTeachers.Add(teacher);
        
    }

    public void RemoveTeacher(Teacher teacher)
    {
        _responsibleTeachers.Remove(teacher);
    }
    
    public Teacher? GetTeacher(string id) => _responsibleTeachers.FirstOrDefault(t => t.Id == id);

    public List<Teacher> GetTeacher(string LastName, string FirstName)
    {
        return _responsibleTeachers.Where(t => t.LastName.Contains(LastName) && t.FirstName.Contains(FirstName)).ToList();
    }
    
    private bool IsTeacherAssigned(Teacher teacher) => _responsibleTeachers.Any(t => t.Id == teacher.Id);
}