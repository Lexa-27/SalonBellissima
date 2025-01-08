using System.ComponentModel.DataAnnotations;

namespace SalonBellissima.Models
{
    public class Categorie
    {
        public int ID { get; set; }

        [Display(Name = "Categorie")]
        public string DenumireCategorie { get; set; }
        public ICollection<Serviciu>? Servicii { get; set; }
    }
}
