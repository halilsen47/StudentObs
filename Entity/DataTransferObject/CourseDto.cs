using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransferObject
{
    public record CourseDto
    {
        public int CourseId { get; init; }
        public string CourseName { get; init;}
    }
}
