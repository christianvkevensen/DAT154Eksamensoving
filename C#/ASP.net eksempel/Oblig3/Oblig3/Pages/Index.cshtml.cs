using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Oblig3.Models;

namespace Oblig3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MyDbContext _context = new MyDbContext();

        [ViewData]
        public List<Student> students { get; set; }

        [ViewData]
        public List<Grade> grades { get; set; }
        
        [ViewData]
        public List<Course> courses { get; set; }


        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            students = await _context.Students.ToListAsync();
            courses = await _context.Courses.ToListAsync();
            grades = await _context.Grades.ToListAsync();
        }

        public async Task<ActionResult> OnPostSearchStudents(String input)
        {
            students = await _context.Students.ToListAsync();
            courses = await _context.Courses.ToListAsync();
            grades = await _context.Grades.ToListAsync();

            students = students.Where(x => x.Studentname.Contains(input)).ToList();
            Console.Write(students[0].Studentname);

            return Page();
        }
    }
}