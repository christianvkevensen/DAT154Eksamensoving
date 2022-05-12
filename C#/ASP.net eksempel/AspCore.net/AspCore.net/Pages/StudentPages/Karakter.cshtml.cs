using AspCore.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspCore.net.Pages.StudentPages
{
    public class KarakterModel : PageModel
    {
        private readonly AspCore.net.Models.StudDbContext _context;

        public KarakterModel(AspCore.net.Models.StudDbContext context)
        {
            _context = context;
        }

        public IList<Grade> Grades { get; set; } = default!;
        public async Task OnGetAsync()
        {
            Grades = await _context.Grades.ToListAsync();
        }
        public async Task OnPostSelectGrade(string gradeSelect)
        {
            var tempGrade = await _context.Grades.ToListAsync();
            Grades = tempGrade.Where(g => g.Grade1.Equals(gradeSelect)).ToList();
        }
    }
}
