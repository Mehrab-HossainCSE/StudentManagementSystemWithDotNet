using StudentManagementSystem.Persistence.Models.Enums;
using StudentManagementSystem.Persistence.Models;

namespace StudentManagementStytem.Service.DTO;

internal class ViewAllStudentsDto
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; } 
    public string? StudentId { get; set; } 
    public Semester? JoiningBatch { get; set; }
    public Department? Department { get; set; } 
    public Degree? Degree { get; set; } 
}
