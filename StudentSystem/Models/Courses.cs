using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentSystem.Models
{
    public class Courses
    {
        [Key]
        public int Courseid { get; set; }
        [MaxLength(80)]
        
        public string Name { get;set; }
       
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime endtDate { get; set; }
        public int Price { get; set; }
        public ICollection<Students> Students { get; set; } = new List<Students>();
        public ICollection<Recources> Recources  { get; set; } = new List <Recources>();
        public ICollection<HomeWorkSubmissions> HomeWorkSubmissions { get; set; } = new List<HomeWorkSubmissions>();
    }
}
