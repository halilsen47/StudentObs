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
        public IActionResult GetAll()
        {
            var students = studentService.GetAllStudent();
            return Ok(students);
        }

        [HttpGet("GetAllWithCourses")]
        public IActionResult GetAllWithCourses()
        {
            var students = studentService.GetAllStudentsWithCourses();
            return Ok(students);
        }


        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            var student = studentService.GetById(id);
            return Ok(student);
        }

      

        [HttpGet("GetByDepartment/{id}")]
        public IActionResult GetByDepartment(int id)
        {
            var students = studentService.GetAllByDepartment(id);
            return Ok(students);
        }


        [HttpPost("Add")]
        public IActionResult Add([FromBody] StudentDtoForAdd studentDto)
        {
            //eğer direkt null değer yollandıysa buraya düşer
            if (studentDto == null)
                throw new StudentNullException(nameof(studentDto));

            //benim girdiğim required,maxlenght vs gibi durumlar buraya düşer
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            studentService.Add(studentDto);
            return StatusCode(201);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] StudentDtoForAdd studentDto)
        {
            if(studentDto == null)
                throw new StudentNullException(nameof(studentDto));

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

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
        [HttpPatch("{id}")]
        [Consumes("application/json-patch+json")]
        [Produces("application/json")]
        public IActionResult UpdateByProp(int id, [FromBody] JsonPatchDocument<StudentDtoForAdd> patchDoc)
        {
            if (patchDoc is null)
            {
                return BadRequest("Unvalid patch request");
            }

            // Öğrenciyi id ile alıyoruz
            var student = studentService.GetById(id);
            if (student == null)
            {
                return NotFound("Student not found");
            }

            // Entity'yi DTO'ya map ediyoruz
            var StudentDtoForAdd = mapper.Map<StudentDtoForAdd>(student);

            // JSON Patch dokümanını DTO'ya uyguluyoruz
            patchDoc.ApplyTo(StudentDtoForAdd);

            // DTO'yu doğrudan Update metoduna gönderiyoruz
            studentService.Update(StudentDtoForAdd);

            return NoContent();
        }
    }


}
 
