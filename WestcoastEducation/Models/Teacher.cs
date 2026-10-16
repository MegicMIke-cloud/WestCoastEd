namespace WestcoastEducation.Models;

public class Teacher : Person
{
    public string KnowledgeArea { get; set; }

    // Kursnummer används för att koppla läraren till kurser utan cirkulära JSON-referenser.
    public List<string> ResponsibleCourseNumbers { get; set; } = new();

    public Teacher(string firstName, string lastName, string phone, string personalIdentityNumber,
        string address, string postalCode, string city, string knowledgeArea)
        : base(firstName, lastName, phone, personalIdentityNumber, address, postalCode, city)
    {
        KnowledgeArea = knowledgeArea;
    }

    public override string GetDisplayInfo() =>
        $"Lärare: {base.GetDisplayInfo()} | Kunskapsområde: {KnowledgeArea} | Ansvarar för {ResponsibleCourseNumbers.Count} kurs(er)";
}
