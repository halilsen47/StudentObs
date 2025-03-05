using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransferObject
{
    public record StudentDtoForDepartment
    {
        public int StudentId { get; set; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string DepartmentName { get; init; }
    }
}
