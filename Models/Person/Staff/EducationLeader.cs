using System.Text.Json.Serialization;

namespace WestCoastEducation.Models.Person.Staff;

public class EducationLeader : PermanentStaff
{
    // The teachers are saved inside the education leader's file
    [JsonInclude]
    private List<Teacher> _responsibleTeachers = new List<Teacher>();

    [JsonIgnore]
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
        _responsibleTeachers.RemoveAll(t => t.Id == teacher.Id);
    }

    public Teacher? GetTeacher(string id) => _responsibleTeachers.FirstOrDefault(t => t.Id == id);

    public List<Teacher> GetTeacher(string LastName, string FirstName)
    {
        return _responsibleTeachers.Where(t => t.LastName.Contains(LastName) && t.FirstName.Contains(FirstName)).ToList();
    }

    private bool IsTeacherAssigned(Teacher teacher) => _responsibleTeachers.Any(t => t.Id == teacher.Id);

    public override string ToString()
    {
        string text = base.ToString();

        if (_responsibleTeachers.Count == 0)
        {
            return text + "\nNot responsible for any teachers";
        }

        text += "\nResponsible for teachers:";
        foreach (var teacher in _responsibleTeachers)
        {
            text += $"\n\t{teacher.FullName} ({teacher.KnowledgeArea})";
        }
        return text;
    }
}
