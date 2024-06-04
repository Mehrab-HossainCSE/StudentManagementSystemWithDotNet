using StudentManagementStytem.Service.DTO;
using StudentManagementSystem.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementStytem.Service.Mapper
{
    internal class ViewAllStudentsMapper
    {
        public static ViewAllStudentsDto MapToDTO(Student student)
        {
            return new ViewAllStudentsDto
            {
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                StudentId = student.StudentId,
                JoiningBatch = student.JoiningBatch,
                Department = student.Department,
                Degree = student.Degree,
            };
        }
    }
}
