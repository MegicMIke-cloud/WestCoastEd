namespace WestcoastEducation.Models;

public class EducationManager : Teacher
{
    public DateTime EmploymentDate { get; set; }

    public EducationManager(string firstName, string lastName, string phone, string personalIdentityNumber,
        string address, string postalCode, string city, string knowledgeArea, DateTime employmentDate)
        : base(firstName, lastName, phone, personalIdentityNumber, address, postalCode, city, knowledgeArea)
    {
        EmploymentDate = employmentDate;
    }

    public override string GetDisplayInfo() =>
        $"Utbildningsledare: {base.GetDisplayInfo()} | Anställd: {EmploymentDate:yyyy-MM-dd}";
}
