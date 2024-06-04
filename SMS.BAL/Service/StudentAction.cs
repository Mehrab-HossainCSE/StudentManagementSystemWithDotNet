using Microsoft.EntityFrameworkCore.Migrations;
using SMS.BAL.DTO;
using SMS.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Persistence.Contacts;
using SMS.BAL.Mapper;
using Microsoft.EntityFrameworkCore;
using SMS.Persistence.Repositories;
using Microsoft.Extensions.Hosting;
namespace SMS.BAL.Service
{
    public class StudentAction : IStudentAction
    {
        public readonly IRepositories _IRepository;
        private readonly StudentMapper _StudentMapper;
      
        public StudentAction(IRepositories IRepository, StudentMapper StudentMapper, IHostEnvironment environment ) 
        {
            
            _IRepository = IRepository;
            _StudentMapper = StudentMapper;
        }
        public async Task<Student> DeleteAsync(int id)
        {
             return await _IRepository.DeleteStudentAsync(id);
            // throw new NotImplementedException();
            //return await _IRepository.InMemoryStudentRep;
        }



        public async Task<List<StudentDTO>> GetStudentsAsync(int pageNumber, int pageSize, string searchString, string sortBy)
        {
            var allStudents = await _IRepository.GetAllStudentsAsync(pageNumber, pageSize, searchString, sortBy);
            var studentDTOs = await _StudentMapper.MapToDtoAsync(allStudents); // Only map the items, not the entire PagedList
            return studentDTOs;
        }

        public async  Task<StudentCourseViewModel> GetStudentIdAsync(int id)
        {
           var indivualStudent= await _IRepository.GetStudentByIdAsync(id);
           // var studentDTos= await _StudentMapper.ConvertIndivualStudent(indivualStudent);
            return indivualStudent;
        }
        public async Task<Student> InsertAsync(Student student)
        {
            return await _IRepository.InsertStudentAsync(student);
           // throw new NotImplementedException();
        }
      public async  Task AddCourse(Course course)
        {
            await _IRepository.AddCourseAsync(course);  
        }
        public async Task<Student> UpdateAsync(int id, Student student)
        {


           return await _IRepository.UpdateStudentAsync(id, student);
            //throw new NotImplementedException();
        }
    }
}
