using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Persistence.Models.Enums;
namespace StudentManagementSystem.Persistence.Models
{
    public class Semester
    {
        public SemesterCode SemesterCode { get; set; }
        public string? Year { get; set; }
        public List<Course> Courses { get; set; }

        public Semester()
        {
            Courses = new List<Course>();
        }

        public Semester(SemesterCode semesterCode, string year)
        {
            SemesterCode = semesterCode;
            Year = year;

        }
    }
}
