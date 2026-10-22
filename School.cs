using WestCoastEducation.Models.Course;
using WestCoastEducation.Models.Person;
using WestCoastEducation.Models.Person.Staff;
using WestCoastEducation.Services;

// The school is the one place the console app talks to. The services it needs come from dependency injection.
class School(CourseService courseService, TeacherService teacherService, StudentService studentService, StaffService staffService)
{
    public void AddCourse(BaseCourse course) => courseService.Create(course);
    public void AddTeacher(Teacher teacher) => teacherService.Create(teacher);
    public void AddStudent(Student student) => studentService.Create(student);
    public void AddEducationLeader(EducationLeader leader) => staffService.Create(leader);
    public void AddAdministrator(Administrator administrator) => staffService.Create(administrator);

    public List<BaseCourse> ListCourses() => courseService.GetAll();
    public List<Teacher> ListTeachers() => teacherService.GetAll();
    public List<Student> ListStudents() => studentService.GetAll();
    public List<PermanentStaff> ListStaff() => staffService.GetAll();

    public void EnrollStudent(Student student, BaseCourse course) => studentService.Enroll(student, course);
    public void AssignTeacherToLeader(EducationLeader leader, Teacher teacher) => staffService.AssignTeacher(leader, teacher);
}
