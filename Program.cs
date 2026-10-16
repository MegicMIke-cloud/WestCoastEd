using WestcoastEducation.Models;
using WestcoastEducation.Services;

namespace WestcoastEducation;

internal class Program
{
    private static readonly EducationCenter Center = new();
    private static readonly CourseJsonService JsonService = new();

    private static void Main()
    {
        JsonService.LoadCourses(Center);
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("       WESTCOAST EDUCATION");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Lista kurser");
            Console.WriteLine("2. Lägg till kurs");
            Console.WriteLine("3. Lista studerande");
            Console.WriteLine("4. Lägg till studerande");
            Console.WriteLine("5. Lista lärare");
            Console.WriteLine("6. Lägg till lärare");
            Console.WriteLine("7. Lägg till utbildningsledare");
            Console.WriteLine("8. Lägg till administratör");
            Console.WriteLine("9. Spara kurser till JSON");
            Console.WriteLine("10. Läs in kurser från JSON");
            Console.WriteLine("0. Avsluta");
            Console.Write("\nVälj ett alternativ: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    Center.ListCourses();
                    Pause();
                    break;
                case "2":
                    AddCourse();
                    Pause();
                    break;
                case "3":
                    Center.ListStudents();
                    Pause();
                    break;
                case "4":
                    AddStudent();
                    Pause();
                    break;
                case "5":
                    Center.ListTeachers();
                    Pause();
                    break;
                case "6":
                    AddTeacher();
                    Pause();
                    break;
                case "7":
                    AddEducationManager();
                    Pause();
                    break;
                case "8":
                    AddAdministrator();
                    Pause();
                    break;
                case "9":
                    JsonService.SaveCourses(Center);
                    Pause();
                    break;
                case "10":
                    JsonService.LoadCourses(Center);
                    Pause();
                    break;
                case "0":
                    JsonService.SaveCourses(Center);
                    running = false;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Välj ett alternativ i menyn.");
                    Pause();
                    break;
            }
        }

        Console.WriteLine("Programmet avslutas. Hej då!");
    }

    private static void AddCourse()
    {
        Console.WriteLine("\n--- Lägg till kurs ---");
        string number = ReadRequired("Kursnummer: ");
        string title = ReadRequired("Kursnamn: ");
        string description = ReadRequired("Beskrivning/innehåll: ");
        int duration = ReadPositiveInt("Längd i dagar: ");
        DateTime startDate = ReadDate("Startdatum (åååå-mm-dd): ");
        DateTime endDate = ReadDate("Slutdatum (åååå-mm-dd): ");

        while (endDate < startDate)
        {
            Console.WriteLine("Slutdatum kan inte vara före startdatum.");
            endDate = ReadDate("Ange slutdatum igen (åååå-mm-dd): ");
        }

        Console.WriteLine("Undervisningsform: 1 = Klassrum, 2 = Distans");
        string formatInput = ReadRequired("Välj form: ");
        while (formatInput != "1" && formatInput != "2")
        {
            Console.WriteLine("Välj 1 eller 2.");
            formatInput = ReadRequired("Välj form: ");
        }

        CourseFormat format = formatInput == "1" ? CourseFormat.Classroom : CourseFormat.Distance;
        bool added = Center.AddCourse(new Course(number, title, description, duration, startDate, endDate, format));

        Console.WriteLine(added ? "Kursen har lagts till." : "Det finns redan en kurs med det kursnumret.");
    }

    private static void AddStudent()
    {
        Console.WriteLine("\n--- Lägg till studerande ---");
        Student student = new(
            ReadRequired("Förnamn: "),
            ReadRequired("Efternamn: "),
            ReadRequired("Telefon: "),
            ReadRequired("Personnummer: "),
            ReadRequired("Adress: "),
            ReadRequired("Postnummer: "),
            ReadRequired("Ort: "));
        Center.AddStudent(student);
        Console.WriteLine("Den studerande har lagts till.");
    }

    private static void AddTeacher()
    {
        Console.WriteLine("\n--- Lägg till lärare ---");
        Teacher teacher = new(
            ReadRequired("Förnamn: "),
            ReadRequired("Efternamn: "),
            ReadRequired("Telefon: "),
            ReadRequired("Personnummer: "),
            ReadRequired("Adress: "),
            ReadRequired("Postnummer: "),
            ReadRequired("Ort: "),
            ReadRequired("Kunskapsområde: "));
        Center.AddTeacher(teacher);
        Console.WriteLine("Läraren har lagts till.");
    }

    private static void AddEducationManager()
    {
        Console.WriteLine("\n--- Lägg till utbildningsledare ---");
        EducationManager manager = new(
            ReadRequired("Förnamn: "),
            ReadRequired("Efternamn: "),
            ReadRequired("Telefon: "),
            ReadRequired("Personnummer: "),
            ReadRequired("Adress: "),
            ReadRequired("Postnummer: "),
            ReadRequired("Ort: "),
            ReadRequired("Kunskapsområde: "),
            ReadDate("Anställningsdatum (åååå-mm-dd): "));
        Center.AddEducationManager(manager);
        Console.WriteLine("Utbildningsledaren har lagts till.");
    }

    private static void AddAdministrator()
    {
        Console.WriteLine("\n--- Lägg till administratör ---");
        Administrator administrator = new(
            ReadRequired("Förnamn: "),
            ReadRequired("Efternamn: "),
            ReadRequired("Telefon: "),
            ReadRequired("Personnummer: "),
            ReadRequired("Adress: "),
            ReadRequired("Postnummer: "),
            ReadRequired("Ort: "),
            ReadRequired("Kunskapsområde: "),
            ReadDate("Anställningsdatum (åååå-mm-dd): "));
        Center.AddAdministrator(administrator);
        Console.WriteLine("Administratören har lagts till.");
    }

    private static string ReadRequired(string prompt)
    {
        Console.Write(prompt);
        string value = Console.ReadLine()?.Trim() ?? "";
        while (string.IsNullOrWhiteSpace(value))
        {
            Console.Write("Fältet får inte vara tomt. Försök igen: ");
            value = Console.ReadLine()?.Trim() ?? "";
        }
        return value;
    }

    private static int ReadPositiveInt(string prompt)
    {
        Console.Write(prompt);
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                return value;
            Console.Write("Skriv ett heltal större än 0: ");
        }
    }

    private static DateTime ReadDate(string prompt)
    {
        Console.Write(prompt);
        while (true)
        {
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                return date;
            Console.Write("Ogiltigt datum. Använd exempelvis 2026-10-16: ");
        }
    }

    private static void Pause()
    {
        Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
        Console.ReadKey(true);
    }
}
