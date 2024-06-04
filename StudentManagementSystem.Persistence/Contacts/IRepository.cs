using StudentManagementSystem.Persistence.Models;
using StudentManagementSystem.Persistence.Models.Enums;

namespace StudentManagementSystem.Persistence.Contacts;

public interface IRepository
{
    List<Student> GetAllStudents();
    Student GetStudentById(string studentId);
    void SaveStudent(Student student);
    void UpdateStudent(Student student);
    void DeleteStudent(Student student);
    void AddSemesterAndCourses(string studentId, SemesterCode semesterCode, string year);
}
