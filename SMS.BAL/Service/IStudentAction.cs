using SMS.BAL.DTO;
using SMS.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BAL.Service
{
    public interface IStudentAction
    {

        
        Task<List<StudentDTO>> GetStudentsAsync(int pageNumber, int pageSize, string searchString, string sortBy);
      
        Task<StudentCourseViewModel> GetStudentIdAsync(int id);
        Task<Student> InsertAsync(Student student);
        Task<Student> DeleteAsync(int id);
        Task<Student> UpdateAsync(int id, Student student);
        Task AddCourse(Course course);
    }
}
