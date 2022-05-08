using System;
using System.Collections.Generic;

namespace CleaningService.Models
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomNumber { get; set; }
        public string? UserName { get; set; }

        public virtual Room RoomNumberNavigation { get; set; } = null!;
        public virtual User? UserNameNavigation { get; set; }
    }
}
