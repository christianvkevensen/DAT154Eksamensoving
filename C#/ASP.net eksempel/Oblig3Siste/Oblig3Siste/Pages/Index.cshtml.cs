#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Oblig3Siste.Models;

namespace Oblig3Siste.Pages
{
    public class IndexModel : PageModel
    {
        [ViewData]
        public List<Student> Students { get; set; } 
        
        [ViewData]
        public List<Course> Courses { get; set; } 
        [ViewData]
        public List<Grade> Grades { get; set; }


        public string SearchString { get; set; }

        private readonly Oblig3Siste.Models.Oblig3Context _context;

        public IndexModel(Oblig3Siste.Models.Oblig3Context context)
        {
            _context = context;
        }

       

        public async Task OnGetAsync()
        {
            
            Students = await _context.Students.ToListAsync();
            Courses = await _context.Courses.ToListAsync();
            Grades = await _context.Grades.ToListAsync();

        }

        public async Task<ActionResult> OnPostSearchStudent(string inp)
        {
            Students = await _context.Students.ToListAsync();
            Courses = await _context.Courses.ToListAsync();
            Grades = await _context.Grades.ToListAsync();

            if (!string.IsNullOrEmpty(inp))
            {
                Students = Students.Where(s => s.Studentname.Contains(inp)).ToList();
            }
            return Page();
        }

        public async Task<ActionResult> OnPostSearchCourse(string selectedCourse)
        {
            Students = await _context.Students.ToListAsync();
            Courses = await _context.Courses.ToListAsync();
            Grades = await _context.Grades.ToListAsync();


            if (!string.IsNullOrEmpty(selectedCourse))
            {
                Grades= Grades.Where(g => g.Coursecode.Equals(selectedCourse)).ToList();
            }

            return Page();
        }

        public async Task<ActionResult> OnPostSearchGrade(string selectedGrade)
        {
            Students = await _context.Students.ToListAsync();
            Courses = await _context.Courses.ToListAsync();
            Grades = await _context.Grades.ToListAsync();

            if (!string.IsNullOrEmpty(selectedGrade))
            {
                Grades = Grades.Where(g=> g.Grade1.CompareTo(selectedGrade) <= 0).ToList();
            }
            return Page();
        }
        public async Task<ActionResult> OnPostSearchF()
        {
            Students = await _context.Students.ToListAsync();
            Courses = await _context.Courses.ToListAsync();
            Grades = await _context.Grades.ToListAsync();

            
            Grades = Grades.Where(g => g.Grade1.CompareTo("F") == 0).ToList();
            
            return Page();
        }

    }
}
