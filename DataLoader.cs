namespace WestCoastEducation;

static class DataLoader
{
    public static void LoadAndPrint(School school)
    {
        PrintAll("Courses", school.ListCourses());
        PrintAll("Teachers", school.ListTeachers());
        PrintAll("Students", school.ListStudents());
        PrintAll("Staff", school.ListStaff());
    }

    //QOL Metod
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
