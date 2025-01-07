using System.ComponentModel.DataAnnotations;

namespace SalonBellissima.Models
{
    public class Programare
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? ServiciuID { get; set; }
        public Serviciu? Servciu { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataProgramare { get; set; }
    }
}
