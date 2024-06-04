using StudentManagementStytem.Service.Attributes;
using StudentManagementStytem.Service.Service;
using StudentManagementSystem.Controllers;
using StudentManagementSystem.Persistence.Models;
using StudentManagementSystem.Persistence.Repositories;

namespace StudentManagementSystem
{
    public class Program
    {
     
        static void Main(string[] args)
        {
            var attributes = Attribute.GetCustomAttributes(typeof(Program));

            //var developerAttribute = attributes.OfType<DeveloperAttribute>().Single();

           // Console.WriteLine(developerAttribute.GetName());


            Course[] courses = CreateCourses();

            string studentDataPath = "student.json";

            Repository studentRepository = new Repository(studentDataPath);

            StudentService studentService = new StudentService(studentRepository, courses);

            StudentController studentController = new StudentController(studentService);

            Menu menu = new Menu(studentController);

            while (true)
            {
                menu.DisplayMenu();
            }

        }
        private static Course[] CreateCourses()
        {
            Course[] courses = new Course[]
            {
                new Course ( "CSE 101", "C Programming", "Prof. Nasir", 3.5),
                new Course ("CSE 102","Machine Learning","Prof. Motiur", 2.5),
                new Course ("CSE 103", "Java Programming", "Prof. Misbah", 3.5),
                new Course ("CSE 104", "Arcitecture", "Prof. Sultan", 2.5),
                new Course ("CSE 105", "Mathematics I", "Prof. Musa" ,3.0)
            };

            return courses;
        }
    }
}
