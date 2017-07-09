using System;
using Microsoft.EntityFrameworkCore;

//Not needed because the query is run in the controller
namespace capstone.Models
{
	public class StudentClassesViewModelContext : DbContext
	{
        public StudentClassesViewModelContext(DbContextOptions<StudentClassesViewModelContext> options)
			: base(options)
		{
		}

		public DbSet<capstone.Models.StudentClassesViewModel> StudentClassesViewModel { get; set; }
	}
}
