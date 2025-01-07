using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace SalonBellissima.Models
{
    public class Serviciu
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        [Display(Name = "Durată aproximativă")]
        public int Durata { get; set; }
        public ICollection<AngajatAsociat>? AngajatiAsociati { get; set; }
        public int? CategorieID { get; set; }
        public Categorie? Categorie { get; set; }
        public ICollection<Programare>? Programari { get; set; }
    }
}
