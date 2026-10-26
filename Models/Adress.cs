namespace WestCoastEducation.Core.Models;

public class Adress
{
    public required string Street { get; set; }
    public required string ZipCode { get; set; }
    public required string Town { get; set; }
    public required string Country { get; set; }

    public override string ToString()
    {
        return $"Adress:\n\t{Street}\n\t{ZipCode}\n\t{Town}\n\t{Country}";
    }

}
