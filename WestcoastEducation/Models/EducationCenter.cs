namespace WestcoastEducation.Models;

// EducationCenter äger samlingarna (composition) och hanterar registrering/listning.
public class EducationCenter
{
    public List<Course> Courses { get; private set; } = new();
    public List<Student> Students { get; private set; } = new();
    public List<Teacher> Teachers { get; private set; } = new();
    public List<EducationManager> EducationManagers { get; private set; } = new();
    public List<Administrator> Administrators { get; private set; } = new();

    public bool AddCourse(Course course)
    {
        foreach (Course existing in Courses)
        {
            if (existing.CourseNumber.Equals(course.CourseNumber, StringComparison.OrdinalIgnoreCase))
                return false;
        }
        Courses.Add(course);
        return true;
    }

    public void AddStudent(Student student) => Students.Add(student);
    public void AddTeacher(Teacher teacher) => Teachers.Add(teacher);
    public void AddEducationManager(EducationManager manager) => EducationManagers.Add(manager);
    public void AddAdministrator(Administrator administrator) => Administrators.Add(administrator);

    public void ListCourses() => PrintList("Kurser", Courses);
    public void ListStudents() => PrintList("Studerande", Students);
    public void ListTeachers() => PrintList("Lärare", Teachers);

    private static void PrintList<T>(string heading, IEnumerable<T> items) where T : IDisplayable
    {
        Console.WriteLine($"\n--- {heading} ---");
        bool found = false;
        foreach (T item in items)
        {
            Console.WriteLine(item.GetDisplayInfo());
            found = true;
        }
        if (!found)
            Console.WriteLine("Listan är tom.");
    }

    public void ReplaceCourses(IEnumerable<Course> courses) => Courses = courses.ToList();
}
