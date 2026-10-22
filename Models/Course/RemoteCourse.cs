namespace WestCoastEducation.Models.Course;

public enum Platform { Zoom, Teams, GoogleMeet, Discord }


public class RemoteCourse : TeacherLeadCourse
{
    public Platform Platform { get; set; }
    public string MeetingLink { get; set; }
    public override CourseType CourseType => CourseType.Remote;

    public RemoteCourse(string teacherId, Platform platform, string meetingLink) : base(teacherId)
    {
        Platform = platform;
        MeetingLink = meetingLink;
    }

    public override string ToString() => $"{base.ToString()}\nPlatform: {Platform}\nMeeting: {MeetingLink}";
}
