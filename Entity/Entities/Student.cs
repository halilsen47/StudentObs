using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress{ get; set; }
        public string Email { get; set; }

        //bir öğrenci birden fazla kursa girebilir
        public ICollection<StudentCourse> StudentCourses { get; set; }
        //bir öğrencinin bir bölümü olabilir
        public int? DepartmentId { get; set; }
        public Department department { get; set; }

    

    }
}
