using System.ComponentModel.DataAnnotations;

namespace Oblig4WebAppBlazor.Models
{
    public class Room
    {
        [Key]
        public int RoomNumber { get; set; }

        public int NumberOfBeds { get; set; }

        public int Quality { get; set; }

        
    }
}
