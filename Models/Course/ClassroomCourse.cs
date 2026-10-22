using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Person.Staff;

namespace WestCoastEducation.Models.Course;

public class ClassroomCourse : TeacherLeadCourse
{
    public Adress Location { get; set; }
    public string LectureHall { get; set; }

    
    public ClassroomCourse(string teacherId, Adress location, string lectureHall) : base(teacherId)
    {
        Location = location;
        LectureHall = lectureHall;
    }
    
    public override string ToString() => $"{Location} Lecture Hall: {LectureHall}";
}