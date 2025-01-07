namespace SalonBellissima.Models
{
    public class ServiciuData
    {
        public IEnumerable<Serviciu> Servicii { get; set; }
        public IEnumerable<Angajat> Angajati { get; set; }
        public IEnumerable<AngajatAsociat> AngajatiAsociati { get; set; }
    }
}
