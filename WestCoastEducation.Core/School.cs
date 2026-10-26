using WestCoastEducation.Core.Models.Course;
using WestCoastEducation.Core.Models.People;
using WestCoastEducation.Core.Models.People.Staff;
using WestCoastEducation.Core.Services;

namespace WestCoastEducation.Core;

public class School
{
    private CourseService CourseService;
    private StudentService StudentService;
    private StaffService StaffService;

    public School(CourseService courseService, StudentService studentService, StaffService staffService)
    {
        CourseService = courseService;
        StudentService = studentService;
        StaffService = staffService;
    }

    public void AddCourse(BaseCourse baseCourse) => Task.Run(() => CourseService.Create(baseCourse)).Wait();
    public void AddTeacher(Teacher teacher) => Task.Run(() => StaffService.Create(teacher)).Wait();
    public void AddStudent(Student student) => Task.Run(() => StudentService.Create(student)).Wait();
    public void AddEducationLeader(EducationLeader leader) => Task.Run(() => StaffService.Create(leader)).Wait();
    public void AddAdministrator(Administrator administrator) => Task.Run(() => StaffService.Create(administrator)).Wait();

    public async Task<List<BaseCourse>> GetAllCourses() => await CourseService.GetAll();
    public async Task<List<Teacher>> GetAllTeachers() => StaffService.Teachers;
    public async Task<List<Student>> GetAllStudents() => await StudentService.GetAll();
    public async Task<List<BaseStaff>> GetAllStaff() => await StaffService.GetAll();
    
    public async Task<Teacher> GetTeacher(string id) => StaffService.Teachers.FirstOrDefault(t => t.Id == id);
    public async Task<Student> GetStudent(string id) => await StudentService.GetSingle(id);
    public async Task<EducationLeader> GetEducationLeader(string id) => (EducationLeader)await StaffService.GetSingle(id);
    public async Task<Administrator> GetAdministrator(string id) => (Administrator)await StaffService.GetSingle(id);
    public async Task<RemoteBaseCourse> GetRemoteCourse(string id) => (RemoteBaseCourse)await CourseService.GetSingle(id);
    public async Task<ClassroomBaseCourse> GetClassroomCourse(string id) => (ClassroomBaseCourse)await CourseService.GetSingle(id);

    public async Task UpdateStudent(Student newStudentData) => await StudentService.Update(newStudentData);
    public async Task UpdateTeacher(Teacher newTeacherData) => await StaffService.Update(newTeacherData);
    public async Task UpdateEducationLeader(EducationLeader newLeaderData) => await StaffService.Update(newLeaderData);
    public async Task UpdateAdministrator(Administrator newAdminData) => await StaffService.Update(newAdminData);
    public async Task UpdateCourse(BaseCourse newBaseCourseData) => await CourseService.Update(newBaseCourseData);
    

    public void AssignCourseToTeacher(Teacher teacher, TeacherLeadBaseCourse baseCourse)
    {
        baseCourse.Teacher = teacher;
        teacher.AddCourse(baseCourse);
        Task.Run(() => CourseService.Update(baseCourse)).Wait();
        Task.Run(() => StaffService.Update(teacher)).Wait();
    }

    public void EnrollStudent(Student student, BaseCourse baseCourse)
    {
        student.Enroll(baseCourse);
        Task.Run(() => StudentService.Update(student));
    }

    public void AssignTeacherToLeader(EducationLeader leader, Teacher teacher)
    {
        leader.AssignTeacher(teacher);
        Task.Run(() => StaffService.Update(leader));
    }
}
