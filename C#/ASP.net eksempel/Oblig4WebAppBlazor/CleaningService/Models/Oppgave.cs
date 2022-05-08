using System.ComponentModel.DataAnnotations;

namespace CleaningService.Models
{
    public class Oppgave
    {
        [Key]
        public int OppgaveId { get; set; }
        public string Notes { get; set; }
        public string Work { get; set; }

        public Room? Room { get; set; }

        public bool Status { get; set; }
    }
}
