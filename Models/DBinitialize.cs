using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace capstone.Models
{
	public static class DBinitialize
	{
		public static void EnsureCreated(IServiceProvider serviceProvider)
		{
			//var context = new MentorContext(
			//	serviceProvider.GetRequiredService<DbContextOptions<MentorContext>>());
			//context.Database.EnsureCreated();

			//var context = new StudentContext(
	  //          serviceProvider.GetRequiredService<DbContextOptions<StudentContext>>());
			//context.Database.EnsureCreated();

	//		var context = new SubjectContext(
	//serviceProvider.GetRequiredService<DbContextOptions<SubjectContext>>());
			//context.Database.EnsureCreated();

	//		var context = new MentorSubjectsContext(
	//serviceProvider.GetRequiredService<DbContextOptions<MentorSubjectsContext>>());
			//context.Database.EnsureCreated();

			var context = new StudentSubjectsContext(
            serviceProvider.GetRequiredService<DbContextOptions<StudentSubjectsContext>>());
			context.Database.EnsureCreated();


		}
	}
}