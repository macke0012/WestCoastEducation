using System.Text.Json.Serialization;

namespace WestCoastEducation.Models.Person.Staff;

public abstract class PermanentStaff : Person
{
    public required DateTime EmploymentDate { get; set; }

    [JsonIgnore]
    public TimeSpan EmploymentDuration => DateTime.Now - EmploymentDate;

    public override string ToString() =>
        $"{base.ToString()}\nRole: {GetType().Name}\nEmployed since: {EmploymentDate:yyyy-MM-dd} ({EmploymentDuration.Days / 365} years)";
}
