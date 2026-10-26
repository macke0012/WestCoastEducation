using WestCoastEducation.Core.Models.People.Staff;

namespace WestCoastEducation.Core.Models.Course;

public class ClassroomBaseCourse : TeacherLeadBaseCourse
{
    public Adress Location { get; set; }
    public string LectureHall { get; set; }
    public override CourseType CourseType => CourseType.Classroom;

    public ClassroomBaseCourse(Adress location, string lectureHall)
    {
        Location = location;
        LectureHall = lectureHall;
    }

    public override string ToString() => $"{base.ToString()}\nLecture Hall: {LectureHall}\n{Location}";
}
