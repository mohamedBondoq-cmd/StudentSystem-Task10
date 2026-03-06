using Microsoft.EntityFrameworkCore;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem.dataaccsess
{
    internal class ApplicationDbContext : DbContext

    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }
        public DbSet<HomeWorkSubmissions> HomeWorkSubmissions { get; set; }
        public DbSet<Recources> Recources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;initial catalog=StudentSystem ;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentCourses>()
                .HasKey(SC => new { SC.StudentId, SC.CourseId });
                
        }

    }

}
