using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentSystem.Models
{
    public enum ResourceType
    {
        Video,
        Presentation,
        Document,
        Other
    }
    public class Recources
    {
        [Key]
        public int ResourceId { get; set; }
        [MaxLength(50)]
        
        public string Name { get; set; }
        public int CourseId { get; set; }
        public Courses? Courses { get; set; }
        [Unicode(false)]
        public string? URL { get;set; }
      
        public ResourceType resourceType { get; set; }
    }
}
