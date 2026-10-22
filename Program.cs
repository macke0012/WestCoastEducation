using Microsoft.Extensions.DependencyInjection;

namespace WestCoastEducation;

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddServices();
        var provider = services.BuildServiceProvider();

        var school = provider.GetRequiredService<School>();

        PrintAll("Courses", school.ListCourses());
        PrintAll("Teachers", school.ListTeachers());
        PrintAll("Students", school.ListStudents());
        PrintAll("Staff", school.ListStaff());
    }

    private static void PrintAll<T>(string heading, List<T> items)
    {
        Console.WriteLine($"===== {heading} ({items.Count}) =====");

        if (items.Count == 0)
        {
            Console.WriteLine("Nothing saved yet");
            Console.WriteLine();
            return;
        }

        foreach (var item in items)
        {
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}
