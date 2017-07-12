using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using capstone.Models;
using Microsoft.Data.Sqlite;

namespace capstone.Controllers
{
    public class MentorsController : Controller
    {
        private readonly MentorContext _context;

        public MentorsController(MentorContext context)
        {
            _context = context;    
        }

        // GET: Mentors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mentor.ToListAsync());
        }

        // GET: Mentors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentor
                .SingleOrDefaultAsync(m => m.ID == id);
            if (mentor == null)
            {
                return NotFound();
            }

            return View(mentor);
        }




		//GET: Students/StudentClasses/5
		//Use the MentorClassesViewModel to create a view for the Student's classes
		public async Task<IActionResult> MentorClasses(int id)
		{
			string connectionString = @"Data Source=/Users/toby/g45/capstone/bin/Debug/netcoreapp1.1/findAMentor.db;";

			MentorClassesViewModel scvm = new MentorClassesViewModel();
			List<MentorClassesViewModel> modelList = new List<MentorClassesViewModel>();

			string sql = "select sub.ID subjectID, sub.name, sub.category,  mentSubs.mentorID, " +
						"ment.first_name, ment.last_name, ment.email, ment.phone " +
						"from subject sub " +
						"inner join mentorSubjects mentSubs " +
						"on sub.ID = mentSubs.subjectID " +
						"inner join Mentor ment " +
						"on ment.ID = mentSubs.mentorID " +
						"where ment.ID = " + id;

			try
			{
				SqliteConnection conn = new SqliteConnection(connectionString);
				conn.Open();
				SqliteCommand command = new SqliteCommand(sql, conn);
				SqliteDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					scvm.first_name = reader["first_name"].ToString();
					scvm.category = reader["category"].ToString();
					scvm.name = reader["name"].ToString();

					modelList.Add(scvm);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception = " + e.Message);
			}

    			return View(modelList);
		}








		// GET: Mentors/Create
		public IActionResult Create()
        {
            return View();
        }

        // POST: Mentors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,first_name,last_name,email,phone,userID,password")] Mentor mentor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mentor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mentor);
        }

        // GET: Mentors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentor.SingleOrDefaultAsync(m => m.ID == id);
            if (mentor == null)
            {
                return NotFound();
            }
            return View(mentor);
        }

        // POST: Mentors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,first_name,last_name,email,phone,userID,password")] Mentor mentor)
        {
            if (id != mentor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mentor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MentorExists(mentor.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(mentor);
        }

        // GET: Mentors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentor
                .SingleOrDefaultAsync(m => m.ID == id);
            if (mentor == null)
            {
                return NotFound();
            }

            return View(mentor);
        }

        // POST: Mentors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mentor = await _context.Mentor.SingleOrDefaultAsync(m => m.ID == id);
            _context.Mentor.Remove(mentor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MentorExists(int id)
        {
            return _context.Mentor.Any(e => e.ID == id);
        }
    }
}
