using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentSystem.Models
{
   public class StudentCourses
    {
        [ForeignKey("StudentId")]  
        public int StudentId { get; set; }
        public Students? Students { get; set; } 
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }
        public Courses? Courses { get; set; } 


    }
}
