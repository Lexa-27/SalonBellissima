namespace SalonBellissima.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string DenumireCategorie { get; set; }
        public ICollection<Serviciu>? Servicii { get; set; }
    }
}
