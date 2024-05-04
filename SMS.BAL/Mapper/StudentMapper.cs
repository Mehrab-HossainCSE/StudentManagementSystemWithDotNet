using SMS.BAL.DTO;
using SMS.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BAL.Mapper
{
    public class StudentMapper
    {
        
        
            public async Task<List<StudentDTO>> MapToDtoAsync(List<Student> students)
            {
                List<StudentDTO> studentDTOs = new List<StudentDTO>();

                // Loop through each student and map it to StudentDTO
                foreach (var student in students)
                {
                    studentDTOs.Add(new StudentDTO
                    {
                        Id = student.Id,
                        FirstName = student.FirstName, // Ensure that these properties are correctly mapped
                        LastName = student.LastName,
                        Email = student.Email,
                        Username=student.Username,
                        Password=student.Password,
                    });
                }

                // Return the list of mapped StudentDTO objects
                return studentDTOs;
            }
        
        public async Task<StudentDTO> ConvertIndivualStudent( Student student) 
        {
            return new StudentDTO { Id = student.Id, FirstName = student.FirstName, LastName = student.LastName, Email = student.Email, Username=student.Username,Password=student.Password};

        }

        }

    
}
