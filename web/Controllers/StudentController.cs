using AutoMapper;
using Azure;
using Entity.DataTransferObject;
using Entity.Entities;
using Entity.Exceptions;
using Entity.RequestFeature;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Services.Abstractions;
using System.Text.Json;
using web.ActionFilters;

namespace web.Controllers
{
    [ServiceFilter(typeof(LogActionAttribute))]
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
        public IActionResult GetAll([FromQuery] BookParameters bookParameters)
        {
            var pagedResault = studentService.GetAllStudent(bookParameters);
            Response.Headers.Add("InfoPageination",
                JsonSerializer.Serialize(pagedResault.metaData));
            return Ok(pagedResault.students);

        }

        [HttpGet("GetAllWithCourses")]
        public IActionResult GetAllWithCourses([FromQuery] BookParameters bookParameters)
        {
            var pagedResault= studentService.GetAllStudentsWithCourses(bookParameters);
            Response.Headers.Add("InfoPageination",
               JsonSerializer.Serialize(pagedResault.metaData));
            return Ok(pagedResault.students);
        }


        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            var student = studentService.GetById(id);
            return Ok(student);
        }

      

        [HttpGet("GetByDepartment/{id}")]
        public IActionResult GetByDepartment([FromQuery] BookParameters bookParameters,int id)
        {
            var pagedResault = studentService.GetAllByDepartment(bookParameters,id);
            Response.Headers.Add("InfoPageination",
                JsonSerializer.Serialize(pagedResault.metaData));
            return Ok(pagedResault.students);
        }

        [ServiceFilter(typeof(ValidationActionAttribute))]
        [HttpPost("Add")]
        public IActionResult Add([FromBody] StudentDtoForAdd studentDto)
        { 

            studentService.Add(studentDto);
            return StatusCode(201);
        }

        [ServiceFilter(typeof(ValidationActionAttribute))]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] StudentDtoForAdd studentDto)
        {
           
            studentService.Update(studentDto);
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState); 

            studentService.Delete(id);
            return NoContent();
        }
         
    }


}
 
