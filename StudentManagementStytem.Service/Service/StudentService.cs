using StudentManagementStytem.Service.DTO;
using StudentManagementStytem.Service.Mapper;
using StudentManagementSystem.Persistence.Models;
using StudentManagementSystem.Persistence.Models.Enums;
using StudentManagementSystem.Persistence.Repositories;

namespace StudentManagementStytem.Service.Service;

public class StudentService : IStudentService
{
    private readonly Repository _studentRepository;
    public readonly Course[] _availableCourses;

    public StudentService(Repository studentRepository, Course[] availableCourses)
    {
        _studentRepository = studentRepository;
        _availableCourses = availableCourses;
    }

    //Get All Student Service
    public IEnumerable<Student> GetAllStudents()
    {
        return _studentRepository.GetAllStudents();
    }

    //Get Student by ID Service
    public Student GetById(string studentId)
    {
        var selectedStudent = _studentRepository.GetAllStudents().FirstOrDefault(s => s.StudentId == studentId);

        return selectedStudent;
    }

    //Add Student Service
    public void AddStudent(string firstName, string middleName, string lastName, string studentId, Department department, Degree degree)
    {

        AddStudentDto newStudent = new AddStudentDto()
        {
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            StudentId = studentId,
            Department = (Department)Enum.Parse(typeof(Department), department.ToString()),
            Degree = (Degree)Enum.Parse(typeof(Degree), degree.ToString()),

        };

        Student studentToAdd = AddStudentMapper.MapToStudent(newStudent);

        _studentRepository.SaveStudent(studentToAdd);
    }

    //Add Semester and Course Service
    public void AddSemesterAndCourses(string studentId, SemesterCode semesterCode, string year)
    {

        var student = _studentRepository.GetStudentById(studentId);

        bool isSemesterAttended = student.SemestersAttended.Any(semester =>
        (SemesterCode)semester.SemesterCode == semesterCode && semester.Year == year);

        if (isSemesterAttended)
        {
            Console.WriteLine("Already attened the course");
        }
        else
        {

            Console.WriteLine("\nAvailable Courses:\n");

            var availableCourses = _availableCourses.Where(c => !student.AttendedCourse.Any(x => x.CourseId == c.CourseId)).ToList();

            foreach (var course in availableCourses)
            {
                Console.WriteLine($"{course.CourseName}");
            }

            Console.WriteLine("\nHow many courses do you want to take? :\n");

            int num = Convert.ToInt32(Console.ReadLine());

            List<Course> courses = new List<Course>();

            for (int i = 0; i < num; i++)
            {
                Console.Write("\nEnter Course ID to add (XXX YYY): ");

                string? selectedCourseID = Console.ReadLine();

                var course = availableCourses.Find(x => x.CourseId == selectedCourseID);

                if (course != null)
                {
                    courses.Add(course);
                    student.AttendedCourse.Add(course);
                    course = null;
                }
                else
                {
                    Console.WriteLine("\ncourse is not available\n");
                }
            }

            Semester joiningSemester = new Semester(semesterCode, year);

            joiningSemester.Courses = courses;
            student.JoiningBatch = joiningSemester;
            student.SemestersAttended.Add(joiningSemester);

            _studentRepository.UpdateStudent(student);
        }
    }

    //Delete Student Service
    public void DeleteStudent(Student student)
    {
        _studentRepository.DeleteStudent(student);
    }
}
