using System;
using Microsoft.EntityFrameworkCore;


namespace capstone.Models
{
    public class MentorContext : DbContext
	{
		public MentorContext(DbContextOptions<MentorContext> options)
            : base(options)
        {
		}

        public DbSet<capstone.Models.Mentor> Mentor { get; set; }
	}
}
