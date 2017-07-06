using System;
using Microsoft.EntityFrameworkCore;


namespace capstone.Models
{
	public class SubjectContext : DbContext
	{
		public SubjectContext(DbContextOptions<SubjectContext> options)
			: base(options)
		{
		}

        public DbSet<capstone.Models.Subject> Subject { get; set; }
	}
}
