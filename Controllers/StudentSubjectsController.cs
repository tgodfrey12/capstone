using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using capstone.Models;

namespace capstone.Controllers
{
    public class StudentSubjectsController : Controller
    {
        private readonly StudentSubjectsContext _context;

        public StudentSubjectsController(StudentSubjectsContext context)
        {
            _context = context;    
        }

        // GET: StudentSubjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentSubjects.ToListAsync());
        }


		// GET: StudentSubjects/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubjects = await _context.StudentSubjects
                .SingleOrDefaultAsync(m => m.ID == id);
            if (studentSubjects == null)
            {
                return NotFound();
            }

            return View(studentSubjects);
        }

        // GET: StudentSubjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,studentID,subjectID")] StudentSubjects studentSubjects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentSubjects);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(studentSubjects);
        }

        // GET: StudentSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubjects = await _context.StudentSubjects.SingleOrDefaultAsync(m => m.ID == id);
            if (studentSubjects == null)
            {
                return NotFound();
            }
            return View(studentSubjects);
        }

        // POST: StudentSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,studentID,subjectID")] StudentSubjects studentSubjects)
        {
            if (id != studentSubjects.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentSubjects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentSubjectsExists(studentSubjects.ID))
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
            return View(studentSubjects);
        }

        // GET: StudentSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubjects = await _context.StudentSubjects
                .SingleOrDefaultAsync(m => m.ID == id);
            if (studentSubjects == null)
            {
                return NotFound();
            }

            return View(studentSubjects);
        }

        // POST: StudentSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentSubjects = await _context.StudentSubjects.SingleOrDefaultAsync(m => m.ID == id);
            _context.StudentSubjects.Remove(studentSubjects);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StudentSubjectsExists(int id)
        {
            return _context.StudentSubjects.Any(e => e.ID == id);
        }
    }
}
