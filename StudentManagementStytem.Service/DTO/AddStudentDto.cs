using StudentManagementSystem.Persistence.Models.Enums;

namespace StudentManagementStytem.Service.DTO;

public class AddStudentDto
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string StudentId { get; set; } = string.Empty;
    public Department Department { get; set; } = Department.None;
    public Degree Degree { get; set; } = Degree.None;
}
