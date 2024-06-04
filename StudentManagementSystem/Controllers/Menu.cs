using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    public class Menu
    {
        public delegate void ShowOptionDelegate(string message); // Show Option delegate
        public delegate string GreetingsDelegate(); //Show Greeting Message Delegate

        private readonly StudentController _studentController;

        public Menu(StudentController studentController)
        {
            _studentController = studentController;
        }

        public static void ShowOption(string menu)
        {
            Console.WriteLine(menu);
        }


        //Show Menu Options with Params Array
        public static void Show(ShowOptionDelegate showDelegate, params string[] options)
        {
            foreach (string option in options)
                showDelegate(option);
        }


        //Display Menu Method
        public void DisplayMenu()
        {
            //Anonymous Greetings Method
            GreetingsDelegate greetings = delegate ()
            {
                return "\nWelcome to Student Management System";
            };

            string GreetingsMessage = greetings.Invoke();

            Console.WriteLine(GreetingsMessage);
            Console.WriteLine("-------------------------------------");

            ShowOptionDelegate optionDelegate = ShowOption;

            Show(optionDelegate, "1. Display All Studnets", "2. View Student", "3. Add New Student", "4. Add Semester and Course", "5. Delete Student", "6. Exit (press 6 to exit)");


            Console.WriteLine("---------------------------");

            string? choice = Console.ReadLine();

            ProcessUserInput(choice);
        }


        //Process User Choice
        private void ProcessUserInput(string choice)
        {
            switch (choice)
            {
                case "1":
                    _studentController.ViewAllStudents();
                    break;
                case "2":
                    _studentController.ViewStudentDetails();
                    break;
                case "3":
                    _studentController.AddStudent();
                    break;
                case "4":
                    _studentController.AddSemesterAndCourses();
                    break;
                case "5":
                    _studentController.DeleteStudent();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

