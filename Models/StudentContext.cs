using System;
using Microsoft.EntityFrameworkCore;


namespace capstone.Models
{
	public class StudentContext : DbContext
	{
		public StudentContext(DbContextOptions<StudentContext> options)
			: base(options)
		{
		}

        public DbSet<capstone.Models.Student> Student { get; set; }
	}
}
