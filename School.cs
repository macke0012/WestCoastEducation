using WestCoastEducation.Interfaces;
using WestCoastEducation.Models.Course;
using WestCoastEducation.Models.Person;
using WestCoastEducation.Models.Person.Staff;
using WestCoastEducation.Services;

class School
{


    private CourseService CourseService;
    private TeacherService TeacherService;
    private StaffService StaffService;



    public School(CourseService courseService, TeacherService teacherService, StaffService staffService)
    {

        CourseService = courseService;
        TeacherService = teacherService;
        StaffService = staffService;

    }

    public void AddTeacher(Teacher teacher)
    {

        TeacherService.Create(teacher);
    }

    public void AddCourse(BaseCourse course)
    {
        CourseService.Create(course);
    }




}
