using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentSystem.Models
{
    public enum contentype
    {
        Application,
        pdf,
        zip
    }
   public class HomeWorkSubmissions
    {
        [Key]
        public int HomeWorkid { get; set; }
        [Unicode(false)]
        public string? content { get; set; }
     
        public contentype Contentype { get; set; }
        public int courseid { get; set; }
        public Courses? Courses { get; set; }
        public int StudentId { get; set; }

        public Students? Students { get; set; }
        public DateTime SubmissionTime { get; set; }


    }
}
