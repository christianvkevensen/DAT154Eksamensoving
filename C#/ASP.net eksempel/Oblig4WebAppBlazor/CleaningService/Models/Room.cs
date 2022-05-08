using System;
using System.Collections.Generic;

namespace CleaningService.Models
{
    public partial class Room
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int RoomNumber { get; set; }
        public int NumberOfBeds { get; set; }
        public int Quality { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
