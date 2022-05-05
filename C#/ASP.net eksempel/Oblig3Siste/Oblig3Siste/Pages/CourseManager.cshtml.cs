#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Oblig3Siste.Models;

namespace Oblig3Siste.Pages
{
    public class CourseManagerModel : PageModel
    {
        private readonly Oblig3Siste.Models.Oblig3Context _context;
        
        [ViewData]
        public List<Student> Students { get; set; }
        [ViewData]
        public List<Course> Courses { get; set; }
        [ViewData]
        public List<Grade> Grades { get; set; }

        public CourseManagerModel(Oblig3Siste.Models.Oblig3Context context)
        {
            _context = context;
        }



        public async Task OnGetAsync(string id)
        {

            Students = await _context.Students.ToListAsync();    
            Courses = await _context.Courses.ToListAsync();
            Grades = await _context.Grades.ToListAsync();

            Grades = Grades.Where(g=>g.Coursecode.Equals(id)).ToList();
            Students.Where(s => s.Grades.Any(g => g.Coursecode != id)).ToList();
        }

        public async Task<IActionResult> OnPostRemoveStudent(string course, string studentId)
        {
            Students = await _context.Students.ToListAsync();
            Courses = await _context.Courses.ToListAsync();
            Grades = await _context.Grades.ToListAsync();

            if(!string.IsNullOrEmpty(course) && !string.IsNullOrEmpty(studentId))
            {
                Grade grade = Grades.Where(g => g.Coursecode.Equals(course) && g.Studentid.ToString().Equals(studentId)).First();
                _context.Grades.Remove(grade);
                _context.SaveChanges();

                Students = await _context.Students.ToListAsync();
                Courses = await _context.Courses.ToListAsync();
                Grades = await _context.Grades.ToListAsync();
                
                Grades = Grades.Where(g => g.Coursecode.Equals(course)).ToList();
            }
            
         
            return Page();

        }

        public async Task<IActionResult> OnPostAddStudent(string course, string studentId, string grade)
        {
            Students = await _context.Students.ToListAsync();
            Courses = await _context.Courses.ToListAsync();
            Grades = await _context.Grades.ToListAsync();

            if (!string.IsNullOrEmpty(course) && !string.IsNullOrEmpty(studentId) && !string.IsNullOrEmpty(grade))
            {
                Grade gradeNew = new Grade();
                gradeNew.Grade1 = grade;
                gradeNew.Studentid = int.Parse(studentId);
                gradeNew.Coursecode = course;
                _context.Grades.Add(gradeNew);
                _context.SaveChanges();

                Students = await _context.Students.ToListAsync();
                Students.Where(s => s.Grades.Any(g => g.Coursecode != course)).ToList();

                Courses = await _context.Courses.ToListAsync();
                Grades = await _context.Grades.ToListAsync();
                Grades = Grades.Where(g => g.Coursecode.Equals(course)).ToList();
            }


            return Page();

        }
    }
}
