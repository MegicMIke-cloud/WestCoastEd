using System.Text.Json;
using System.Text.Json.Serialization;
using WestcoastEducation.Models;

namespace WestcoastEducation.Services;

public class CourseJsonService
{
    private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "courses.json");

    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public void SaveCourses(EducationCenter center)
    {
        try
        {
            string json = JsonSerializer.Serialize(center.Courses, _options);
            File.WriteAllText(_filePath, json);
            Console.WriteLine($"Kurser sparade i: {_filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Kunde inte spara kurserna: {ex.Message}");
        }
    }

    public void LoadCourses(EducationCenter center)
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("Ingen JSON-fil finns ännu. En fil skapas när du sparar kurser.");
                return;
            }

            string json = File.ReadAllText(_filePath);
            List<Course>? courses = JsonSerializer.Deserialize<List<Course>>(json, _options);
            if (courses is not null)
            {
                center.ReplaceCourses(courses);
                Console.WriteLine($"{courses.Count} kurs(er) lästes in från JSON.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Kunde inte läsa JSON-filen: {ex.Message}");
        }
    }
}
