using WestCoastEducation.Models.Course;

namespace WestCoastEducation.Models.Person;

class Student
{
    public List<BaseCourse> Courses { get; private set; } = [];

    public override string ToString()
    {
        string baseString = base.ToString() ?? "";
        string additionString = "";
        
        Courses.ForEach(c => additionString += $"\nCourse: {c.CourseNumber}\n\t{c.Title}\n\tDuration: {c.DurationInWeeks}");
        
        return  baseString + additionString;
    }
}
