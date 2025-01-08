using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace SalonBellissima.Models
{
    public class Serviciu
    {
        public int ID { get; set; }

        [Display(Name = "Serviciu")]
        public string Denumire { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Pret { get; set; }
        [Display(Name = "Durată aproximativă")]
        public int Durata { get; set; }
        [Display(Name = "Angajat")]
        public ICollection<AngajatAsociat>? AngajatiAsociati { get; set; }
        public int? CategorieID { get; set; }
        public Categorie? Categorie { get; set; }
        public ICollection<Programare>? Programari { get; set; }
    }
}
