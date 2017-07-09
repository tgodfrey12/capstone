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
    public class StudentsController : Controller
    {
        private readonly StudentContext _context;

        public StudentsController(StudentContext context)
        {
            _context = context;    
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var thing = await _context.Student.ToListAsync();

            return View(await _context.Student.ToListAsync());
        }

        //GET: Students/StudentClasses/5
        //Use the StudentClassesViewModel to create a view for the Student's classes
        public async Task<IActionResult> StudentClasses(int id)
        {
            string connectionString = @"Data Source=/Users/toby/g45/capstone/bin/Debug/netcoreapp1.1/findAMentor.db;";

            StudentClassesViewModel scvm = new StudentClassesViewModel();
            List<StudentClassesViewModel> modelList = new List<StudentClassesViewModel>();

			string sql = "select sub.ID subjectID, sub.name, sub.category,  studSubs.studentID, " +
							"stud.first_name, stud.last_name, stud.email, stud.phone " +
							"from subject sub " +
							"inner join studentSubjects studSubs " +
							"on sub.ID = studSubs.subjectID " +
							"inner join Student stud " +
							"on stud.ID = studSubs.studentID " +
							"where stud.ID = " + id;

			try
			{
				SqliteConnection conn = new SqliteConnection(connectionString);
				conn.Open();
				SqliteCommand command = new SqliteCommand(sql, conn);
				SqliteDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					//student = MapStudent(reader, student);
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

 
        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            string connectionString = @"Data Source=/Users/toby/g45/capstone/bin/Debug/netcoreapp1.1/findAMentor.db;";
            Student student = new Student();

            try
            {
                SqliteConnection conn = new SqliteConnection(connectionString);
                conn.Open();
                string sql = "select * from Student where ID = " + id.ToString();
                SqliteCommand command = new SqliteCommand(sql, conn);
                SqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    student = MapStudent(reader, student);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception = " + e.Message);
            }

            return View(student);
        }

        private Student MapStudent(SqliteDataReader reader, Student student)
        {
            //Student student = new Student();
            student.first_name = reader["first_name"].ToString();
            student.last_name = reader["last_name"].ToString();
            student.email = reader["email"].ToString();
            student.phone = reader["phone"].ToString();
            student.userID = reader["userID"].ToString();
            student.password = reader["password"].ToString();


            return student;
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,first_name,last_name,email,phone,userID,password,age")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,first_name,last_name,email,phone,userID,password,age")] Student student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.ID))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.SingleOrDefaultAsync(m => m.ID == id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.ID == id);
        }
    }
}
