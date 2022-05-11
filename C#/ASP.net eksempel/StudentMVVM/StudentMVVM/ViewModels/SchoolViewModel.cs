using StudentMVVM.Models;

namespace StudentMVVM.ViewModels
{
    public class SchoolViewModel : ISchoolViewModel
    {
        public List<Student> students { get; set; } = new List<Student>();
        public List<Grade> grades { get; set; } = new List<Grade>();
        public List<Course> courses { get; set; } = new List<Course>();

        public Student student { get; set; } = new Student();
        public Grade grade { get; set; } = new Grade();
        public Course course { get; set; } = new Course();
        private HttpClient _httpClient;

        public SchoolViewModel()
        {}

        public SchoolViewModel(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task searchStudent()
        {
            students.Clear();
            List<Student> studentsTemp = await _httpClient.GetFromJsonAsync<List<Student>>("api/Students");
            studentsTemp = studentsTemp.Where(s=>s.Studentname.Contains(student.Studentname)).ToList();
            foreach (Student student in studentsTemp)
            {
                students.Add(student);
            }
        }
        public async Task getCourse(string id)
        {
            this.course = new Course();
            course = await _httpClient.GetFromJsonAsync<Course>("api/Courses/" + id);

            this.grades = new List<Grade>();
            List<Grade> tmp = await _httpClient.GetFromJsonAsync<List<Grade>>("api/Grades");
            this.grades = tmp.Where(g => g.Coursecode.Equals(course.Coursecode)).ToList();
        }

        public async Task GetStudents()
        {
            List<Student> studentsTemp = await _httpClient.GetFromJsonAsync<List<Student>>("api/Students");
            foreach (Student student in studentsTemp)
            {
                students.Add(student);
            }
        }
        public async Task GetGrades()
        {
            List<Grade> gradesTemp = await _httpClient.GetFromJsonAsync<List<Grade>>("api/Grads");
            foreach (Grade g in gradesTemp)
            {
                grades.Add(g);
            }
        }
        public async Task GetCourses()
        {
            List<Course> coursesTemp = await _httpClient.GetFromJsonAsync<List<Course>>("api/Courses");
            foreach (Course c in coursesTemp)
            {
                courses.Add(c);
            }
        }

    }
}
