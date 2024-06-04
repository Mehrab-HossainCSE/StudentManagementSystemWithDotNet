namespace StudentManagementSystem.Persistence.Models;

public class Course
{
    public string? CourseId { get; set; } 
    public string? CourseName { get; set; }
    public string? InstructorName { get; set; } 
    public double? NumberOfCredits { get; set; }

    public Course(string courseID, string courseName, string instructorName, double credits)
    {
        CourseId = courseID;
        CourseName = courseName;
        InstructorName = instructorName;
        NumberOfCredits = credits;
    }
}
