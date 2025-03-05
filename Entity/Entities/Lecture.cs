using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Lecture 
    {
        public int LectureId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        //bir hoca birden fazla departmanta ders verebilir
        public ICollection<LectureDepartments> LectureDepartments{ get; set; }

        //bir hoca birden fazla kurs verebilir
        public ICollection<Course> Courses { get; set; }
    }
}
