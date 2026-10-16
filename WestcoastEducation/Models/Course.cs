namespace WestcoastEducation.Models;

public class Course : IDisplayable
{
    public string CourseNumber { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int DurationDays { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public CourseFormat Format { get; set; }
    public double AverageRating { get; set; }

    // Aggregation: kursen håller reda på lärarnas ID/kursnummer, inte själva objekten.
    public List<string> TeacherNames { get; set; } = new();

    public Course(string courseNumber, string title, string description, int durationDays,
        DateTime startDate, DateTime endDate, CourseFormat format)
    {
        CourseNumber = courseNumber;
        Title = title;
        Description = description;
        DurationDays = durationDays;
        StartDate = startDate;
        EndDate = endDate;
        Format = format;
        AverageRating = 0;
    }

    public string GetDisplayInfo() =>
        $"{CourseNumber} | {Title} | {FormatText()} | {DurationDays} dagar | {StartDate:yyyy-MM-dd} till {EndDate:yyyy-MM-dd} | Betyg: {AverageRating:0.0}";

    private string FormatText() => Format == CourseFormat.Classroom ? "Klassrum" : "Distans";
}
