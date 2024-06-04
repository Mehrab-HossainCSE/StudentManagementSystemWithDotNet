using Microsoft.EntityFrameworkCore;
using SMS.Persistence.Contacts;
using SMS.Persistence.Data;
using SMS.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Persistence.Repositories
{
    public class InMemoryStudentRepository : IRepositories
    {

        private readonly InMemoryDataContext _context;
        public InMemoryStudentRepository(InMemoryDataContext context)
        {
            _context = context;

        }
        public async Task<Student> DeleteStudentAsync(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    await _context.SaveChangesAsync();
                }
                return student;
            }
            catch (Exception ex)
            {
                // Log the exception here or handle it appropriately
                throw; // Re-throw the exception to propagate it further
            }
        }

       
        public async Task<List<Student>> GetAllStudentsAsync(int pageNumber, int pageSize, string searchString, string sortBy)
        {
            try
            {
                var query = _context.Students.AsQueryable();

                // Filtering
                if (!string.IsNullOrEmpty(searchString))
                {
                    query = query.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString) || s.Email.Contains(searchString));
                }

                // Sorting
                switch (sortBy)
                {
                    case "Id":
                        query = query.OrderBy(s => s.Id);
                        break;
                    case "email":
                        query = query.OrderBy(s => s.Email);
                        break;
                    default:
                        query = query.OrderByDescending(s => s.FirstName);
                        break;
                }

                // Paging
                var totalItems = await query.CountAsync();
                var students = await query.Skip((pageNumber - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();

                return students;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving students: {ex.Message}");
            }
        }


        public async Task<StudentCourseViewModel> GetStudentByIdAsync(int id)
        {
            var studentCourse = await (from student in _context.Students
                                       join course in _context.courses
                                       on student.Id equals course.Id // Joining based on both student.Id and course.Id
                                       where student.Id == id && course.Id == id // Filtering based on both IDs
                                       select new StudentCourseViewModel
                                       {
                                           Id = student.Id,
                                           Username = student.Username,
                                           Password = student.Password,
                                           FirstName = student.FirstName,
                                           LastName = student.LastName,
                                           Email = student.Email,
                                           course = course.course // Assuming the course name is stored in the 'course' property of the Course entity
                                       }).FirstOrDefaultAsync();
            return studentCourse;
        }
        public async Task<Student> InsertStudentAsync(Student student)
        {
            try
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return student;
            }
            catch (Exception ex)
            {
                // Log the exception here or handle it appropriately
                throw; // Re-throw the exception to propagate it further
            }
        }

        public async Task AddCourseAsync(Course course)
        {
            try
            {
                _context.courses.Add(course);
                await _context.SaveChangesAsync();
                //return student;
            }
            catch (Exception ex)
            {
                // Log the exception here or handle it appropriately
                throw; // Re-throw the exception to propagate it further
            }
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            var selectedStudent = await _context.Students.FirstOrDefaultAsync(y => y.Id == id);

            if (selectedStudent == null)
            {
                return null;
            }

            selectedStudent.FirstName = student.FirstName;
            selectedStudent.Email = student.Email;
            selectedStudent.LastName = student.LastName;
            selectedStudent.Username = student.Username;
            selectedStudent.Password = student.Password;
            await _context.SaveChangesAsync();

            return selectedStudent;
        }
    }
}
