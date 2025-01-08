using System.ComponentModel.DataAnnotations;

namespace SalonBellissima.Models
{
    public class Programare
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? ServiciuID { get; set; }
        public Serviciu? Serviciu { get; set; }
        [Required(ErrorMessage = "Vă rog selectați o dată pentru programare.")]
        [Display(Name = "Data programării")]
        [DataType(DataType.Date)]
        public DateTime DataProgramare { get; set; }

        [Required(ErrorMessage = "Vă rog selectați o oră pentru programare.")]
        [Display(Name = "Ora programării")]
        public TimeSpan OraProgramare { get; set; }
    }
}

