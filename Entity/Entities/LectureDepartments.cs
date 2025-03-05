using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class LectureDepartments
    {
        public int LectureDepartmentId { get; set; }
        //Foregin Key
        public int? LectureId { get; set; }
        public int? DepartmentId { get; set; }

        //Navigation Property
        public Lecture Lecture { get; set; }
        public Department Department { get; set; }
    }
}
