namespace WestcoastEducation.Models;

// Basklass: gemensamma uppgifter finns på ett enda ställe.
public abstract class Person : IDisplayable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string PersonalIdentityNumber { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }

    protected Person(string firstName, string lastName, string phone,
        string personalIdentityNumber, string address, string postalCode, string city)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        PersonalIdentityNumber = personalIdentityNumber;
        Address = address;
        PostalCode = postalCode;
        City = city;
    }

    public virtual string GetDisplayInfo() =>
        $"{FirstName} {LastName} | Telefon: {Phone} | Ort: {PostalCode} {City}";
}
