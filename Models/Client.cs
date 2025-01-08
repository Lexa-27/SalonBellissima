using System.ComponentModel.DataAnnotations;

namespace SalonBellissima.Models
{
    public class Client
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage =
"Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau AnaMaria")]
        [StringLength(30, MinimumLength = 3)]
        public string? Prenume { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
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
