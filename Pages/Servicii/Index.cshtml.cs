using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SalonBellissima.Data;
using SalonBellissima.Models;

namespace SalonBellissima.Pages.Servicii
{
    public class IndexModel : PageModel
    {
        private readonly SalonBellissima.Data.SalonBellissimaContext _context;

        public IndexModel(SalonBellissima.Data.SalonBellissimaContext context)
        {
            _context = context;
        }

        public IList<Serviciu> Serviciu { get; set; }
        public ServiciuData ServiciuD { get; set; }
        public int ServiciuID { get; set; }
        public int AngajatID { get; set; }
        public string TitleSort { get; set; }
        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(int? id, int? angajatID, string sortOrder, string searchString)
        {
            ServiciuD = new ServiciuData();

            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";

            CurrentFilter = searchString;

            ServiciuD.Servicii = await _context.Serviciu
            .Include(b => b.Categorie)
            .Include(b => b.AngajatiAsociati)
            .ThenInclude(b => b.Angajat)
            .AsNoTracking()
            .OrderBy(b => b.Denumire)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                ServiciuD.Servicii = ServiciuD.Servicii.Where(s => s.Denumire.Contains(searchString));
            }

            if (id != null)
            {
                ServiciuID = id.Value;
                Serviciu serviciu = ServiciuD.Servicii
                .Where(i => i.ID == id.Value).Single();
                ServiciuD.Angajati = serviciu.AngajatiAsociati.Select(s => s.Angajat);
            }

            switch (sortOrder)
            {
                case "title_desc":
                    ServiciuD.Servicii = ServiciuD.Servicii.OrderByDescending(s =>
                   s.Denumire);
                    break;
                default:
                    ServiciuD.Servicii = ServiciuD.Servicii.OrderBy(s => s.Denumire);
                    break;
            }
        }
    }
}
