using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransferObject
{
    public record StudentDtoForAdd : StudentDtoForManupilation
    {
        //ekleme işleminde department atanıyor fakat course veya courselar atanmıyor 
        public int DepartmentId { get; init; }
    }
}
