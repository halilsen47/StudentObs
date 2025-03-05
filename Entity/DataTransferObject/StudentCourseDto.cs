using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransferObject
{
    public record StudentCourseDto
    {
        public int StudentId { get; init; }
        public string FirstName{ get; init; }
        public string LastName{ get; init; }
        public string departmentName { get; init; }
        public List<CourseDto> Courses { get; init; }
    }
}
