using System.Security.Policy;
using SalonBellissima.Models;

namespace SalonBellissima.Models.ViewModels
{
    public class CategorieIndexData
    {
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<Serviciu> Servicii { get; set; }
    }
}
