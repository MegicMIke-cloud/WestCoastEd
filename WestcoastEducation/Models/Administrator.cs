namespace WestcoastEducation.Models;

public class Administrator : EducationManager
{
    public Administrator(string firstName, string lastName, string phone, string personalIdentityNumber,
        string address, string postalCode, string city, string knowledgeArea, DateTime employmentDate)
        : base(firstName, lastName, phone, personalIdentityNumber, address, postalCode, city, knowledgeArea, employmentDate) { }

    public override string GetDisplayInfo() => $"Administratör: {base.GetDisplayInfo()}";
}
