using System;
using Microsoft.EntityFrameworkCore;

namespace capstone.Models
{
	public class MentorSubjectsContext : DbContext
	{
		public MentorSubjectsContext(DbContextOptions<MentorSubjectsContext> options)
			: base(options)
		{
		}

        public DbSet<capstone.Models.MentorSubjects> MentorSubjects { get; set; }
	}
}
