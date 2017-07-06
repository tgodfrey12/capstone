using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using capstone.Models;

    public class Mentor_subjectContext : DbContext
    {
        public Mentor_subjectContext (DbContextOptions<Mentor_subjectContext> options)
            : base(options)
        {
        }

        //public DbSet<capstone.Models.Mentor_subject> Mentor_subject { get; set; }
    }
