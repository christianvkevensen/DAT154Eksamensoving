using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
