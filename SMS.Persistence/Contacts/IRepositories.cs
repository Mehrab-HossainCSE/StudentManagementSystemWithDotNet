using SMS.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Persistence.Contacts
{
    public interface IRepositories
    {


        //Task<List<Student>> GetAllStudentsAsync();
        Task<List<Student>> GetAllStudentsAsync(int pageNumber, int pageSize, string searchString, string sortBy);
        Task<StudentCourseViewModel> GetStudentByIdAsync(int id);
        Task<Student> InsertStudentAsync(Student student);
        Task<Student> DeleteStudentAsync(int id);
        Task<Student> UpdateStudentAsync(int id,Student student);
        Task AddCourseAsync(Course courser);



    }
}
