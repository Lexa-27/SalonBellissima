using System.ComponentModel.DataAnnotations;

namespace SalonBellissima.Models
{
    public class Angajat
    {
        public int ID { get; set; }
        public string Prenume { get; set; }
        public string Nume { get; set; }

        [Display(Name = "Nume stilist")]
        public string NumeAngajat
        {
            get { return Prenume + " " + Nume; }
        }
        public ICollection<AngajatAsociat>? AngajatiAsociati { get; set; }
    }
}
