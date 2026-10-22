using Microsoft.Extensions.DependencyInjection;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Repositories;
using WestCoastEducation.Services;

public static class ServiceCollectionExtensions
{

    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<IStorageProvider, JsonStorageService>();
        collection.AddSingleton<CourseService>();
        collection.AddSingleton<TeacherService>();
        collection.AddSingleton<StaffService>();
        collection.AddSingleton<School>();
    }
}