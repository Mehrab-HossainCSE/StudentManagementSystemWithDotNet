using StudentManagementSystem.Persistence.Models;
using StudentManagementSystem.Persistence.Models.Enums;

namespace StudentManagementStytem.Service.DTO
{
    public class ViewStudentDto
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public Semester? JoiningBatch { get; set; }
        public Department Department { get; set; } = Department.None;
        public Degree Degree { get; set; } = Degree.None;
        public List<Course> AttendedCourse { get; set; }
        public List<Semester> SemestersAttended { get; set; }

        public ViewStudentDto()
        {
            JoiningBatch = new Semester();
        }
    }
}
