using StudentManagementStytem.Service.DTO;
using StudentManagementSystem.Persistence.Models;

namespace StudentManagementStytem.Service.Mapper
{
    internal class ViewStudentMapper
    {
        public static ViewStudentDto MapToDTO(Student student)
        {
            return new ViewStudentDto
            {
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                StudentId = student.StudentId,
                Department = student.Department,
                Degree = student.Degree,
            };
        }
        public static Student MapToStudent(ViewStudentDto student)
        {
            return new Student
            {
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                StudentId = student.StudentId,
                Department = student.Department,
                Degree = student.Degree,
            };
        }
    }
}
