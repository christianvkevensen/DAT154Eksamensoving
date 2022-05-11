using StudentMVVM.Models;

namespace StudentMVVM.ViewModels
{
    public interface ISchoolViewModel 
    {
        public List<Student> students { get; set; } 
        public List<Grade> grades { get; set; } 
        public List<Course> courses { get; set; } 

        public Student student { get; set; }
        public Grade grade { get; set; }
        public Course course { get; set; }

        public async Task GetStudents()
        {}
        public async Task searchStudent() { }
        public async Task GetCourses() { 
        }
        public async Task searchStudCourse(string course) { }

        public async Task GetGrades() { }

        public async Task getCourse(string id) { }

    }
}

