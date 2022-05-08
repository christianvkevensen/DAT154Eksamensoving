using System;
using System.Collections.Generic;

namespace CleaningService.Models
{
    public partial class User
    {
        public User()
        {
            Reservations = new HashSet<Reservation>();
        }

        public string UserName { get; set; } = null!;

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
