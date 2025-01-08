using System.ComponentModel.DataAnnotations;

namespace SalonBellissima.Models
{
    public class Angajat
    {
        public int ID { get; set; }
        public string Prenume { get; set; }
        public string Nume { get; set; }

        [Display(Name = "Nume")]
        public string NumeAngajat
        {
            get { return Prenume + " " + Nume; }
        }
        [Display(Name = "Ocupație")]
        public string Ocupatie { get; set; }
        public ICollection<AngajatAsociat>? AngajatiAsociati { get; set; }
    }
}
