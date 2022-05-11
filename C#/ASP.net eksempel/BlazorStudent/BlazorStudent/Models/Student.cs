using System;
using System.Collections.Generic;

namespace BlazorStudent.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string Studentname { get; set; } = null!;
        public int Studentage { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }

        public static implicit operator Student(HttpResponseMessage v)
        {
            throw new NotImplementedException();
        }
    }
}
