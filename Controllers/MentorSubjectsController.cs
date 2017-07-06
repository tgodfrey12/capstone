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
    public class MentorSubjectsController : Controller
    {
        private readonly MentorSubjectsContext _context;

        public MentorSubjectsController(MentorSubjectsContext context)
        {
            _context = context;    
        }

        // GET: MentorSubjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.MentorSubjects.ToListAsync());
        }

        // GET: MentorSubjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentorSubjects = await _context.MentorSubjects
                .SingleOrDefaultAsync(m => m.ID == id);
            if (mentorSubjects == null)
            {
                return NotFound();
            }

            return View(mentorSubjects);
        }

        // GET: MentorSubjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MentorSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,mentorID,subjectID")] MentorSubjects mentorSubjects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mentorSubjects);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mentorSubjects);
        }

        // GET: MentorSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentorSubjects = await _context.MentorSubjects.SingleOrDefaultAsync(m => m.ID == id);
            if (mentorSubjects == null)
            {
                return NotFound();
            }
            return View(mentorSubjects);
        }

        // POST: MentorSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,mentorID,subjectID")] MentorSubjects mentorSubjects)
        {
            if (id != mentorSubjects.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mentorSubjects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MentorSubjectsExists(mentorSubjects.ID))
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
            return View(mentorSubjects);
        }

        // GET: MentorSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentorSubjects = await _context.MentorSubjects
                .SingleOrDefaultAsync(m => m.ID == id);
            if (mentorSubjects == null)
            {
                return NotFound();
            }

            return View(mentorSubjects);
        }

        // POST: MentorSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mentorSubjects = await _context.MentorSubjects.SingleOrDefaultAsync(m => m.ID == id);
            _context.MentorSubjects.Remove(mentorSubjects);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MentorSubjectsExists(int id)
        {
            return _context.MentorSubjects.Any(e => e.ID == id);
        }
    }
}
