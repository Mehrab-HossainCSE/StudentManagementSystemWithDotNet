using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.BAL.DTO;
using SMS.BAL.Service;
using SMS.Persistence.Models;

using System.Net;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentManagementServiceController : ControllerBase
    {
        public readonly IStudentAction _actionResult;
       // private object _iRepository;

        public StudentManagementServiceController(IStudentAction actionResult)
        {
            _actionResult = actionResult;


        }
        
        [HttpPut]
        [Route("GetStudents")]
        [Authorize]
        [ResponseCache(Duration = 20, Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> Get(int pageNumber = 1, int pageSize = 10, string searchString = "", string sortBy = "name")
        {
            var items = await _actionResult.GetStudentsAsync(pageNumber, pageSize, searchString, sortBy);
            if (items == null)
            {
                return NotFound(); // Return 404 Not Found if no students are found
            }
            return Ok(items); // Return the list of students with a 200 OK status
        }
        [HttpGet]
        [Route("GetStudentByID")]
        [Authorize]
        [ResponseCache(Duration = 20, Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> Get(int id)
        {
            var items= await _actionResult.GetStudentIdAsync(id);
            if(items == null)
            {
                return NotFound();
            }
            return Ok(items);

        }
        [HttpPost]
        [Route("AddStudent")]
        //  [Authorize]
        
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest(); // Return 400 Bad Request if the student data is not provided
            }

            try
            {
                var insertedStudent = await _actionResult.InsertAsync(student);
                return Ok(insertedStudent); // Return the inserted student
            }
            catch (Exception ex)
            {
                // Log the exception here or handle it appropriately
                var errorMessage = $"Internal server error: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $" Inner Exception: {ex.InnerException.Message}";
                }
                return StatusCode(500, errorMessage); // Return 500 Internal Server Error
            }
        }


        [HttpPut]
        [Route("UpdateStudent")]
      //  [Authorize]
        public async Task<IActionResult> Update(int id, Student student)
        {
            try
            {
                var updatedStudent = await _actionResult.UpdateAsync(id, student);
                if (updatedStudent != null)
                {
                    return Ok(updatedStudent); // Return 200 OK with the updated student
                }
                else
                {
                    return NotFound(); // Return 404 Not Found if the student with the given id is not found
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Return 500 Internal Server Error
            }
        }
        [HttpDelete]
        [Route("DeleteStudent")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletedStudent = await _actionResult.DeleteAsync(id);
                if (deletedStudent != null)
                {
                    return Ok(deletedStudent); // Return 200 OK with the updated student
                }
                else
                {
                    return NotFound(); // Return 404 Not Found if the student with the given id is not found
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Return 500 Internal Server Error
            }
        }

    }
}
