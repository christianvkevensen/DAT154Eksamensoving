using AspCore.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspCore.net.Pages.StudentPages
{
    public class SingleStudentModel : PageModel
    {
        private readonly AspCore.net.Models.StudDbContext _context;

        public SingleStudentModel(AspCore.net.Models.StudDbContext context)
        {
            _context = context;
        }

        public Student student { get; set; }
        public async Task OnGetAsync(int id)
        {
            student = await _context.Students.FindAsync(id);
        }
    }
}
