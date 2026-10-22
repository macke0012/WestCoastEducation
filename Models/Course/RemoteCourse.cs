using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Person.Staff;

namespace WestCoastEducation.Models.Course;

public enum Platform { Zoom, Teams, GoogleMeet, Discord }


public class RemoteCourse : TeacherLeadCourse
{
    public Platform Platform { get; set; }
    public string MeetingLink { get; set; }
    
    public override string ToString() => $"{base.ToString()}\nPlatform: {Platform}\nMeeting: {MeetingLink}";

    public RemoteCourse(string teacherId, Platform platform, string meetingLink) : base(teacherId)
    {
        Platform = platform;
        MeetingLink = meetingLink;
    }
}