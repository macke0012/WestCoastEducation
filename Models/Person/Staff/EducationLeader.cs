using System.Text.Json.Serialization;

namespace WestCoastEducation.Models.Person.Staff;

public class EducationLeader : PermanentStaff
{
    // Only the teacher ids are saved, so each teacher stays in its own file
    [JsonInclude]
    public List<string> TeacherIds { get; private set; } = [];

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
        TeacherIds.Add(teacher.Id);
        _responsibleTeachers.Add(teacher);
    }

    public void RemoveTeacher(Teacher teacher)
    {
        TeacherIds.Remove(teacher.Id);
        _responsibleTeachers.RemoveAll(t => t.Id == teacher.Id);
    }

    public Teacher? GetTeacher(string id) => _responsibleTeachers.FirstOrDefault(t => t.Id == id);

    public List<Teacher> GetTeacher(string LastName, string FirstName)
    {
        return _responsibleTeachers.Where(t => t.LastName.Contains(LastName) && t.FirstName.Contains(FirstName)).ToList();
    }

    /// <summary>
    /// Picks out the teachers this education leader is responsible for
    /// </summary>
    /// <param name="allTeachers">Every saved teacher</param>
    public void LoadTeachers(List<Teacher> allTeachers)
    {
        _responsibleTeachers.Clear();
        foreach (var teacher in allTeachers)
        {
            if (TeacherIds.Contains(teacher.Id))
            {
                _responsibleTeachers.Add(teacher);
            }
        }
    }

    private bool IsTeacherAssigned(Teacher teacher) => TeacherIds.Contains(teacher.Id);

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
