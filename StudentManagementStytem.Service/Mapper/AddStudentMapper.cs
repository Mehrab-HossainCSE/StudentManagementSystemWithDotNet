using StudentManagementStytem.Service.DTO;
using StudentManagementSystem.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementStytem.Service.Mapper
{
    internal class AddStudentMapper
    {
        public static AddStudentDto MapToDTO(Student student)
        {
            return new AddStudentDto
            {
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                StudentId = student.StudentId,
                Department = student.Department,
                Degree = student.Degree,
            };
        }
        public static Student MapToStudent(AddStudentDto addStudentDTO)
        {
            return new Student
            {
                FirstName = addStudentDTO.FirstName,
                MiddleName = addStudentDTO.MiddleName,
                LastName = addStudentDTO.LastName,
                StudentId = addStudentDTO.StudentId,
                Department = addStudentDTO.Department,
                Degree = addStudentDTO.Degree,

            };
        }

    }
}
