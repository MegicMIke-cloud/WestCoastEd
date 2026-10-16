namespace WestcoastEducation.Models;

public class Student : Person
{
    public List<string> CourseHistory { get; set; } = new();

    public Student(string firstName, string lastName, string phone, string personalIdentityNumber,
        string address, string postalCode, string city)
        : base(firstName, lastName, phone, personalIdentityNumber, address, postalCode, city) { }

    public override string GetDisplayInfo() =>
        $"Studerande: {base.GetDisplayInfo()} | Kurser i historiken: {CourseHistory.Count}";
}
