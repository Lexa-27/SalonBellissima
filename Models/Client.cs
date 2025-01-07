using System.ComponentModel.DataAnnotations;

namespace SalonBellissima.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string? Prenume { get; set; }
        public string? Nume { get; set; }
        public string Email { get; set; }
        [Display(Name = "Nume Client")]
        public string? NumeClient
        {
            get
            {
                return Prenume + " " + Nume;
            }
        }
        public ICollection<Programare>? Programari { get; set; }
    }
}
