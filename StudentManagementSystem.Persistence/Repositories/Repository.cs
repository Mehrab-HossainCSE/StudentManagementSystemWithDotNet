using Newtonsoft.Json;
using StudentManagementSystem.Persistence.Contacts;
using StudentManagementSystem.Persistence.Models.Enums;
using StudentManagementSystem.Persistence.Models;
using StudentManagementSystem.Persistence.Context;
namespace StudentManagementSystem.Persistence.Repositories
{
    public class Repository : IRepository
    {
        private readonly string _filePath;

        public Repository(string filePath)
        {
            _filePath = filePath;
        }

        //Get All Students from File
        public List<Student> GetAllStudents()
        {
            string jsonData = File.ReadAllText(_filePath);
            return StudentManagementSystem.Persistence.Context. JsonConverter.FromJson<List<Student>>(jsonData) ?? new List<Student>();
        }

        //Get Student by ID from File
        public Student GetStudentById(string studentId)
        {
            List<Student> students = GetAllStudents();
            return students.FirstOrDefault(s => s.StudentId == studentId);
        }

        //Save Student to File
        public void SaveStudent(Student student)
        {
            List<Student> students = GetAllStudents();

            students.Add(student);

            string jsonData = StudentManagementSystem.Persistence.Context.JsonConverter.ToJson(students);

            File.WriteAllText(_filePath, jsonData);
        }


        //Update Existing Student in the File
        public void UpdateStudent(Student student)
        {
            List<Student> students = GetAllStudents();

            int index = students.FindIndex(s => s.StudentId == student.StudentId);
            students[index] = student;

            string jsonData = StudentManagementSystem.Persistence.Context.JsonConverter.ToJson(students);

            File.WriteAllText(_filePath, jsonData);
        }

        //Delete Student from File
        public void DeleteStudent(Student student)
        {
            List<Student> students = GetAllStudents();
            students.RemoveAll(s => s.StudentId == student.StudentId);

            string jsonData = StudentManagementSystem.Persistence.Context.JsonConverter.ToJson(students);
            File.WriteAllText(_filePath, jsonData);
        }


        //Add Semester and Courses to Student
        public void AddSemesterAndCourses(string studentId, SemesterCode semesterCode, string year)
        {
            Student student = GetStudentById(studentId);

            if (student == null)
                throw new ArgumentException("Student not found with ID: " + studentId);

            Semester newSemester = new Semester(semesterCode, year);

            student.SemestersAttended.Add(newSemester);

            SaveStudent(student);
        }
    }
}