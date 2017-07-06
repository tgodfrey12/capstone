using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using capstone.Models;

    public class Student_subjectContext : DbContext
    {
        public Student_subjectContext (DbContextOptions<Student_subjectContext> options)
            : base(options)
        {
        }

        //public DbSet<capstone.Models.Student_subject> Student_subject { get; set; }
    }
