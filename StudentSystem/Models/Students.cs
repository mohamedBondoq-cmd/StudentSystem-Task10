using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentSystem.Models
{
public class Students
    {
        [Key]
        public int StudentId { get; set; }
        public DateTime? Birthday { get; set; }
        [MaxLength(100)]
        
        public string Name { get; set; }
        [MaxLength(10)]
        [Unicode(false)]
        public string? PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public ICollection<Courses> Courses { get; set; } = new List<Courses>();
        public ICollection<HomeWorkSubmissions> HomeWorkSubmissions { get; set; } =  new List<HomeWorkSubmissions>();
            
    }
}
