using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransferObject
{
    public record StudentDto : StudentDtoForManupilation
    {
        public int StudentId { get; init; }
        public string DepartmentName { get; init; }
        public List<CourseDto> Courses { get; init; }
       
    }
}
