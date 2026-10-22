namespace WestCoastEducation.Models.Person.Staff;

public abstract class PermanentStaff : Person
{
    public required DateTime EmploymentDate { get; set; }
    public TimeSpan EmploymentDuration => DateTime.Now - EmploymentDate;
}