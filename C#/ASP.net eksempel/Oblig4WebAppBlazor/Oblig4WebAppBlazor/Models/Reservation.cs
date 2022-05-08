namespace Oblig4WebAppBlazor.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public DateTime startDate { get; set; }   
        public DateTime endDate { get; set; }   

        public Room room { get; set; }
        
        public User user { get; set; }
    }
}
