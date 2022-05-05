using System.ComponentModel.DataAnnotations;

namespace Oblig4WebAppBlazor.Models
{
    public class User
    {
        
        [Key]
        public string UserName { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set;}
    }
}
