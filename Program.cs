using Microsoft.Extensions.DependencyInjection;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;
using WestCoastEducation.Models.Course;
using WestCoastEducation.Models.Person.Staff;
using WestCoastEducation.Repositories;

namespace WestCoastEducation;

class Program
{
    static void Main(string[] args)
    {
        var DepService = new ServiceCollection();
        DepService.AddServices();
        var provider = DepService.BuildServiceProvider();
        
        var school = provider.GetRequiredService<School>();
        
        
    }
}