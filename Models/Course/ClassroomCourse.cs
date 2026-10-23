namespace WestCoastEducation.Models.Course;

public class ClassroomCourse : TeacherLeadCourse
{
    public Adress Location { get; set; }
    public string LectureHall { get; set; }
    public override CourseType CourseType => CourseType.Classroom;

    public ClassroomCourse(string teacherId, Adress location, string lectureHall) : base(teacherId)
    {
        Location = location;
        LectureHall = lectureHall;
    }

    public override string ToString() => $"{base.ToString()}\nLecture Hall: {LectureHall}\n{Location}";
}
