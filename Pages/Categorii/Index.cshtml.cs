using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalonBellissima.Data;
using SalonBellissima.Models;
using SalonBellissima.Models.ViewModels;

namespace SalonBellissima.Pages.Categorii
{
    public class IndexModel : PageModel
    {
        private readonly SalonBellissima.Data.SalonBellissimaContext _context;

        public IndexModel(SalonBellissima.Data.SalonBellissimaContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get; set; } = default!;

        public CategorieIndexData CategorieData { get; set; }
        public int CategorieID { get; set; }
        public int ServiciuID { get; set; }
        public async Task OnGetAsync(int? id, int? serviciuID)
        {
            CategorieData = new CategorieIndexData();
            CategorieData.Categorii = await _context.Categorie
            .Include(i => i.Servicii)
            .OrderBy(i => i.DenumireCategorie)
            .ToListAsync();
            if (id != null)
            {
                CategorieID = id.Value;
                Categorie categorie = CategorieData.Categorii
                .Where(i => i.ID == id.Value).Single();
                CategorieData.Servicii = categorie.Servicii;
            }
        }
    }
}
