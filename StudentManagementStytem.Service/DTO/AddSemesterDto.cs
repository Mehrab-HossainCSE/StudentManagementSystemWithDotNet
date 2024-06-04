using StudentManagementSystem.Persistence.Models;

namespace StudentManagementStytem.Service.DTO;

public class AddSemesterDto
{
    public Semester? JoiningBatch { get; set; }
    public List<Course> AttendedCourse { get; set; }
    public List<Semester> SemestersAttended { get; set; }
}
