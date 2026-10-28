using System.ComponentModel;

namespace WestCoastEducation.Core.Models;

public class Adress
{
    [DisplayName("Gatuadress")]
    public required string Street { get; set; }
    [DisplayName("Postnummer")]
    public required string ZipCode { get; set; }
    [DisplayName("Postort")]
    public required string Town { get; set; }
    [DisplayName("Land")]
    public required string Country { get; set; }

    public override string ToString()
    {
        return $"{Street}\n{ZipCode}\n{Town}\n{Country}";
    }

    public Adress()
    {
        
    }
    
    public Adress(string street, string zipCode, string town, string country)
    {
        Street = street;
        ZipCode = zipCode;
        Town = town;
        Country = country;
    }

}
