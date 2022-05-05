using Oblig3Ny_Blazor.Models;
using System.Collections.Generic;

namespace Oblig3Ny_Blazor.Models
{
    public class StudentService
    {
        private readonly Oblig3Context context;
        public StudentService(Oblig3Context context)
        {
            this.context = context;
        }

        public List<Student> searchStudents(string inp)
        {
            List<Student> students = context.Students.Where(s => s.Studentname.Contains(inp)).ToList();

            return students;
        }
    }
}
