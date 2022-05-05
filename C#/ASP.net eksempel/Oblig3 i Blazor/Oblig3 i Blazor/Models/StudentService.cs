namespace Oblig3_i_Blazor.Models
{
    public class StudentService
    {
        private readonly Oblig3Context context;
        public List<Student> students;
        public StudentService(Oblig3Context oblig3Context)
        {
            this.context = oblig3Context;
        }

        public List<Student> searchStudents(string inp)
        {
            return students = context.Students.Where(s => s.Studentname.Contains(inp)).ToList();
        }
    }
}
