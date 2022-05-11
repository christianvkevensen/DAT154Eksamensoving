using System;
using System.Collections.Generic;

namespace StudentMVVM.Models
{
    public partial class Course : ICourse
    {
        public Course()
        {
            Grades = new HashSet<Grade>();
        }

        public string Coursecode { get; set; } = null!;
        public string Coursename { get; set; } = null!;
        public string Semester { get; set; } = null!;
        public string Teacher { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
