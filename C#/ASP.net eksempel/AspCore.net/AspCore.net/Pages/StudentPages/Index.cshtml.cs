using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspCore.net.Models;

namespace AspCore.net.Pages.StudentPages
{
    public class IndexModel : PageModel
    {
        private readonly AspCore.net.Models.StudDbContext _context;

        public IndexModel(AspCore.net.Models.StudDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students.ToListAsync();
                ViewData["students"] = Student;
            }
        }
        [HttpPost]
        public async Task OnPostSearchStudent(string searchBar)
        {
            if(_context.Students != null)
            {
                var tempstup = await _context.Students.ToListAsync();
                Student=tempstup.Where(s=>s.Studentname.Contains(searchBar)).ToList();
            }
            
        }
       
    }
}
