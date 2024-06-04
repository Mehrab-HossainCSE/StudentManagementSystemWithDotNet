using StudentManagementSystem.Persistence.Models.Enums;

namespace StudentManagementSystem.Persistence.Models;

public class Student
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

    public Student()
    {
        SemestersAttended = [];
        AttendedCourse = [];
        JoiningBatch = null;
    }

    // Method Overriding (Polymorphism)
    public override string ToString()
    {
        if (JoiningBatch != null)
        {
            return $"Name: {FirstName}, Id: {StudentId}, Joining Batch: {JoiningBatch.SemesterCode + " " + JoiningBatch.Year}, Degree: {(Degree)Degree}, Department: {(Department)Department}";
        }
        return $"Name: {FirstName}, Id: {StudentId}, Degree: {(Degree)Degree}, Department: {(Department)Department}";
    }

}

