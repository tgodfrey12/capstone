using System;
using Microsoft.EntityFrameworkCore;

namespace capstone.Models
{
	public class StudentSubjectsContext : DbContext
	{
		public StudentSubjectsContext(DbContextOptions<StudentSubjectsContext> options)
			: base(options)
		{
		}

		public DbSet<capstone.Models.StudentSubjects> StudentSubjects { get; set; }
	}
}
