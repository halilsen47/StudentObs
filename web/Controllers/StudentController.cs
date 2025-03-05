using AutoMapper;
using Azure;
using Entity.DataTransferObject;
using Entity.Entities;
using Entity.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstractions;

namespace web.Controllers
{
    [Route("api")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly ILoggerService logger;
        private readonly IMapper mapper;
        public StudentController(IStudentService studentService, ILoggerService logger, IMapper mapper)
        {
            this.studentService = studentService;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var students = await studentService.GetAllStudentAsync();
            return Ok(students);
        }

        [HttpGet("GetAllWithCourses")]
        public async Task<IActionResult> GetAllWithCourses()
        {
            var students = await studentService.GetAllStudentsWithCoursesAsync();
            return Ok(students);
        }


        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await studentService.GetByIdAsync(id);
            return Ok(student);
        }

      

        [HttpGet("GetByDepartment/{id}")]
        public async Task<IActionResult> GetByDepartment(int id)
        {
            var students = await studentService.GetAllByDepartmentAsync(id);
            return Ok(students);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] StudentDtoForAdd studentDto)
        {
            //eğer direkt null değer yollandıysa buraya düşer
            if (studentDto == null)
                throw new StudentNullException(nameof(studentDto));

            //benim girdiğim required,maxlenght vs gibi durumlar buraya düşer
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await studentService.AddAsync(studentDto);
            return StatusCode(201);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] StudentDtoForAdd studentDto)
        {
            if(studentDto == null)
                throw new StudentNullException(nameof(studentDto));

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await studentService.UpdateAsync(studentDto);
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState); 

            await studentService.DeleteAsync(id);
            return NoContent();
        }
        
    }


}
 
