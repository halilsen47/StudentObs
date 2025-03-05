﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class StudentCourse 
    {
        public int StudentCourseId { get; set; }

        //Foregin Key
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        //Navigation Property
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
