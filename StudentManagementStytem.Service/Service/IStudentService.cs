using StudentManagementSystem.Persistence.Models.Enums;
using StudentManagementSystem.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementStytem.Service.Service
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetById(string studentId);
        void AddStudent(string firstName, string middleName, string lastName, string studentId, Department department, Degree degree);
        void DeleteStudent(Student student);
        void AddSemesterAndCourses(string studentId, SemesterCode semesterCode, string year);
    }
}
