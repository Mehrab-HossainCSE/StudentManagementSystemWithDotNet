using StudentManagementStytem.Service.DTO;
using StudentManagementSystem.Persistence.Models;

namespace StudentManagementStytem.Service.Mapper;

internal class AddSemesterMapper
{
    public static AddSemesterDto MapToDTO(Student student)
    {
        return new AddSemesterDto
        {
            JoiningBatch = student.JoiningBatch,
            AttendedCourse = student.AttendedCourse,
            SemestersAttended = student.SemestersAttended,
        };
    }
}
