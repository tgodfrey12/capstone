using System;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Mvc;
using capstone.Models;


namespace capstone.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Login(string email, string password)
        {
            string connectionString = @"Data Source=/Users/toby/g45/capstone/bin/Debug/netcoreapp1.1/findAMentor_Saved.db;";

            string studentSQL = "SELECT * FROM Student where email = " + "'" + email + "'" +
                " AND password = " + "'" + password + "'";

			string mentorSQL = "SELECT * FROM Mentor where email = " + "'" + email + "'" +
				" AND password = " + "'" + password + "'";

			try
			{
				SqliteConnection conn = new SqliteConnection(connectionString);
				conn.Open();
				SqliteCommand command = new SqliteCommand(studentSQL, conn);
				SqliteDataReader reader = command.ExecuteReader();

                //Check to see if the user is a student
				while (reader.Read())
				{
                    if (reader.HasRows)
                    {
                        int studentID = Int32.Parse(reader["ID"].ToString());
                        return RedirectToAction("StudentClasses", "Students", new { id = studentID });
                    }
                    else
                        break;
				}

				SqliteCommand mentorCommand = new SqliteCommand(mentorSQL, conn);
				reader = mentorCommand.ExecuteReader();

                while(reader.Read())
                {
					if (reader.HasRows)
					{
                        int mentorID = Int32.Parse(reader["ID"].ToString());
						return RedirectToAction("MentorClasses", "Mentors", new { id = mentorID });
					}
					else
						break;
                }
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception = " + e.Message);
			}


            //TODO: If not a student or a mentor, redirect to a signup page and 
            //add a link to the signup page on index

            return null;
        }




    }
}
