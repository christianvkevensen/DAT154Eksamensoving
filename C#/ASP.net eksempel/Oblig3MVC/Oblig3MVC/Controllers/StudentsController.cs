#nullable disable
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Oblig3MVC.Models;

namespace Oblig3MVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly Oblig3Context _context;

        public StudentsController(Oblig3Context context)
        {
            _context = context;
        }
        //Search


        // GET: Students
        public ViewResult Index(string input, string selectedCourse)
        {

            var students = _context.Students.ToList();
            var courses = _context.Courses.ToList();
            var grades = _context.Grades.ToList();
            var studentCourses = new List<Grade>();
            var foundGrades = new List<Grade>();
            //var foundGrades = new List<Grade>();

            if (!string.IsNullOrEmpty(input))
            {
                students = students.Where(s => s.Studentname.Contains(input)).ToList();
            }
            if (!string.IsNullOrEmpty(selectedCourse))
            {
                studentCourses = grades.Where(g => g.Coursecode.Equals(selectedCourse)).ToList();
            }
            ViewBag.StudentCourses = studentCourses;
            ViewBag.Students = students;
            ViewBag.Courses = courses;
            ViewBag.Grades = grades;
            ViewBag.FoundGrades = foundGrades;

            return View(ViewBag);
        }


        public IActionResult searchGrades(string selectedGrade)
        {
            var students = _context.Students.ToList();
            var courses = _context.Courses.ToList();
            var grades = _context.Grades.ToList();
            List<Grade> foundGrades = new List<Grade>();

            if (!string.IsNullOrEmpty(selectedGrade))
            {
                foundGrades = grades.Where(g => g.Grade1.CompareTo(selectedGrade) <= 0).ToList();
            }
            Console.WriteLine("major bag");
            Console.WriteLine(foundGrades[0].Grade1);
            ViewData["FoundGrades"] = foundGrades;
            ViewBag.FoundGrades= foundGrades;


            
            return RedirectToAction(nameof(Index));

            //return View();
        }



        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Studentname,Studentage")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Studentname,Studentage")] Student student)
        {
            if (id != student.Id)
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
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
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

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
