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

        if (school.ListCourses().Count == 0)
        {
            DataCreator.CreateAndSave(school);
        }

        DataLoader.LoadAndPrint(school);
    }
}
