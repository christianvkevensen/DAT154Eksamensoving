using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dat154EntitiesNew dx = new dat154EntitiesNew();

            var students = dx.student;
            var grade = dx.grade;
            var course = dx.course;

            foreach(student s in students.
                Where(s => s.studentname.Contains("S")).ToList()){
                Console.WriteLine(s.studentname);
            }
        }
    }
}
