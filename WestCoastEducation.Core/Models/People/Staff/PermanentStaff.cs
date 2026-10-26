using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace WestCoastEducation.Core.Models.People.Staff;

public abstract class PermanentStaff : BaseStaff
{
    public required DateTime EmploymentDate { get; set; }
    public string Role => GetType().Name;

    [BsonIgnore]
    public TimeSpan EmploymentDuration => DateTime.Now - EmploymentDate;

    public override string ToString() =>
        $"{base.ToString()}\nRole: {GetType().Name}\nEmployed since: {EmploymentDate:yyyy-MM-dd} ({EmploymentDuration.Days / 365} years)";
}
