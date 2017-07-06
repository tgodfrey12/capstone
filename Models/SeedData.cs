using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace capstone.Models
{
    public static class SeedData
    {
        //public SeedData()
        //{
        //}

        public static void Initialize(IServiceProvider serviceProvider)
        {
            //using (var context = new MentorContext(
            //    serviceProvider.GetRequiredService<DbContextOptions<MentorContext>>()))
            //{
            //    if (context.Mentor.Any())
            //    {
            //        return;   // DB has been seeded
            //    }

            //    context.Mentor.AddRange(
            //        new Mentor
            //        {
            //            first_name = "Gene",
            //            last_name = "Simmons",
            //            email = "GS@kiss.com",
            //            phone = "512-123-4567",
            //            userID = "GSimmons",
            //            password = "GSimmons"
            //        },
            //        new Mentor
            //        {
            //            first_name = "Gordon",
            //            last_name = "Sumner",
            //            email = "GS@sting.com",
            //            phone = "234-674-3245",
            //            userID = "Sting",
            //            password = "TheP0lice"
            //        },
            //        new Mentor
            //        {
            //            first_name = "Steve",
            //            last_name = "Wozniak",
            //            email = "SW@apple.com",
            //            phone = "204-321-4587",
            //            userID = "Woz",
            //            password = "SWoz"
            //        },
            //        new Mentor
            //        {
            //            first_name = "Sheryl",
            //            last_name = "Crow",
            //            email = "SC@gmail.com",
            //            phone = "345-637-0238",
            //            userID = "SCrow",
            //            password = "AllIWannaDo"
            //        }
            //    );

            //    context.SaveChanges();
            //}

            //using (var context = new StudentContext(
            //    serviceProvider.GetRequiredService<DbContextOptions<StudentContext>>()))
            //{
                //if (context.Student.Any())
                //{
                //    return;   // DB has been seeded
                //}

                //context.Student.AddRange(
                //    new Student
                //    {
                //        first_name = "Barak",
                //        last_name = "Obama",
                //        email = "BO@wh.com",
                //        phone = "234-232-3245",
                //        userID = "BObama",
                //        password = "ThePrez",
                //        age = 53
                //    },
                //    new Student
                //    {
                //        first_name = "Al",
                //        last_name = "Gore",
                //        email = "AG@internets.com",
                //        phone = "213-564-9834",
                //        userID = "AGore",
                //        password = "ConvenientLie",
                //        age = 72
                //    },
                //    new Student
                //    {
                //        first_name = "Toby",
                //        last_name = "Godfrey",
                //        email = "godfreytoby@gmail.com",
                //        phone = "614-668-8462",
                //        userID = "tgodfrey",
                //        password = "findme",
                //        age = 50
                //    }
                //);

                //try
                //{
                //    context.SaveChanges();
                //}
                //catch(Exception e)
                //{
                //    System.Diagnostics.Debug.WriteLine("Exception Thrown: ", e.Message);
                //}


				using (var context = new SubjectContext(
					serviceProvider.GetRequiredService<DbContextOptions<SubjectContext>>()))
				{
					if (context.Subject.Any())
					{
						return;   // DB has been seeded
					}

					context.Subject.AddRange(
						new Subject
						{
							name = "guitar",
                            category = "Musical Instruments"
						},
						new Subject
						{
							name = "piano",
							category = "Musical Instruments"
						},
						new Subject
						{
							name = "trumpet",
							category = "Musical Instruments"
						},
						new Subject
						{
							name = "trombone",
							category = "Musical Instruments"
						},
						new Subject
						{
							name = "bass guitar",
							category = "Musical Instruments"
						},
						new Subject
						{
							name = "violin",
							category = "Musical Instruments"
						},
						new Subject
						{
							name = "double bass",
							category = "Musical Instruments"
						},
						new Subject
						{
							name = "middle school math",
							category = "Mathematics"
						},
						new Subject
						{
							name = "algebra 1",
							category = "Mathematics"
						},
						new Subject
						{
							name = "geometry",
							category = "Mathematics"
						},
						new Subject
						{
							name = "algebra 2",
							category = "Mathematics"
						},
						new Subject
						{
							name = "precalculus",
							category = "Mathematics"
						},
						new Subject
						{
							name = "calculus",
							category = "Mathematics"
						},
						new Subject
						{
							name = "english",
							category = "Languages"
						},
						new Subject
						{
							name = "spanish",
							category = "Languages"
						},
											new Subject
											{
												name = "french",
												category = "Languages"
											},
											new Subject
											{
												name = "german",
												category = "Languages"
											},
											new Subject
											{
												name = "japanese",
												category = "Languages"
											},
											new Subject
											{
												name = "reading",
												category = "Academics"
											},
											new Subject
											{
												name = "writing",
												category = "Academics"
											},

																new Subject
																{
																	name = "history",
																	category = "Academics"
																}



					);

					try
					{
						context.SaveChanges();
					}
					catch (Exception e)
					{
						System.Diagnostics.Debug.WriteLine("Exception Thrown: ", e.Message);
					}



				}//End Initialize()
        }
    }
}
