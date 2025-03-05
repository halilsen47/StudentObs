using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Course 
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int AKTS { get; set; }
        public int Credit{ get; set; }
        
        //bir course da birden fazla öğrenci olabilir
        public ICollection<StudentCourse> StudentCourses { get; set; }

        //bir kursu bir hoca alabilir
        public int? LectureId { get; set; }
        public Lecture Lecture { get; set; }

    }
}
