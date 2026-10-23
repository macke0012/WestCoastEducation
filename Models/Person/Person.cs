namespace WestCoastEducation.Models.Person;

public abstract class Person : IStorageObject
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string SSN { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required Adress Adress { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    public string Id { get; init; } = Guid.NewGuid().ToString();

    public override string ToString()
    {
        return $"{FullName}\nSSN: {SSN}\nPhone: {PhoneNumber}\nEmail: {Email}\n{Adress}";
    }
}
