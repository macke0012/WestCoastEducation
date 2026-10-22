using WestCoastEducation.Models.Course;
using WestCoastEducation.Models.Person;
using WestCoastEducation.Models.Person.Staff;
using WestCoastEducation.Services;

// The school is the one place the console app talks to. The services it needs come from dependency injection.
class School
{
    private CourseService CourseService;
    private TeacherService TeacherService;
    private StudentService StudentService;
    private StaffService StaffService;

    public School(CourseService courseService, TeacherService teacherService, StudentService studentService, StaffService staffService)
    {
        CourseService = courseService;
        TeacherService = teacherService;
        StudentService = studentService;
        StaffService = staffService;
    }

    public void AddCourse(BaseCourse course) => CourseService.Create(course);
    public void AddTeacher(Teacher teacher) => TeacherService.Create(teacher);
    public void AddStudent(Student student) => StudentService.Create(student);
    public void AddEducationLeader(EducationLeader leader) => StaffService.Create(leader);
    public void AddAdministrator(Administrator administrator) => StaffService.Create(administrator);

    public List<BaseCourse> ListCourses() => CourseService.GetAll();
    public List<Teacher> ListTeachers() => TeacherService.GetAll();
    public List<Student> ListStudents() => StudentService.GetAll();
    public List<PermanentStaff> ListStaff() => StaffService.GetAll();

    public void AssignCourseToTeacher(Teacher teacher, TeacherLeadCourse course)
    {
        course.TeacherId = teacher.Id;
        teacher.AddCourse(course);
        CourseService.Update(course);
        TeacherService.Update(teacher);
    }

    public void EnrollStudent(Student student, BaseCourse course)
    {
        student.Enroll(course);
        StudentService.Update(student);
    }

    public void AssignTeacherToLeader(EducationLeader leader, Teacher teacher)
    {
        leader.AssignTeacher(teacher);
        StaffService.Update(leader);
    }
}
