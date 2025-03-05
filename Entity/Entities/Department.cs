using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Department 
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        //bir departmentta birden fazla öğrenci olabilir
        public ICollection<Student> Students { get; set; } 

        //bir departmantta birden fazla hoca olabilir
        public ICollection<LectureDepartments> LectureDepartments { get; set; }
    }
}
