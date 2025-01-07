namespace SalonBellissima.Models
{
    public class AngajatAsociat
    {
        public int ID { get; set; }
        public int ServiciuID { get; set; }
        public Serviciu Serviciu { get; set; }
        public int AngajatID { get; set; }
        public string NumeAngajat => $"{Angajat?.Prenume} {Angajat?.Nume}";
        public Angajat Angajat { get; set; } //navigation property 


    }
}
